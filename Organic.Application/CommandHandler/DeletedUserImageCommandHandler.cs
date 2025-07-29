using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Organic.Application.Command.User;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler
{
    public class DeletedUserImageCommandHandler : IRequestHandler<DeletedUserImageCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;

        public DeletedUserImageCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _env = env;
        }

        public async Task<string> Handle(DeletedUserImageCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserId))
                return "کاربر احراز هویت نشده است.";

            // 2. گرفتن تصویر از دیتابیس
            var queryRepo = _unitOfWork.QueryRepository<UserImageModel>();
            var commandRepo = _unitOfWork.CommandRepository<UserImageModel>();

            var image = await queryRepo.GetByIdAsync(Guid.Parse(currentUserId));
            if (image == null)
                return "تصویری برای حذف یافت نشد.";

            // 3. حذف فیزیکی فایل در سرور
            var wwwRootPath = _env.WebRootPath;
            var fullImagePath = Path.Combine(wwwRootPath, image.FilePath);

            if (!string.IsNullOrEmpty(image.FilePath) && File.Exists(fullImagePath))
            {
                File.Delete(fullImagePath);
            }

            // 4. حذف رکورد دیتابیس (اختیاری)
            await commandRepo.Delete(image);
            await _unitOfWork.SaveChangeAsync();

            return "تصویر با موفقیت حذف شد.";
        }
    }
}
