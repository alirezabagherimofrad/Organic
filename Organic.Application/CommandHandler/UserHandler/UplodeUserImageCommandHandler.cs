using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Organic.Application.Command.User;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Organic.Application.CommandHandler.UserHandler
{
    public class UplodeUserImageCommandHandler : IRequestHandler<UplodeUserImageCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenricQueryRepository<UserImageModel> _genricQueryRepository;
        private readonly IGenricCommandRepository<UserImageModel> _genricCommandRepository;

        public UplodeUserImageCommandHandler(IUnitOfWork unitOfWork, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor, 
            IGenricQueryRepository<UserImageModel> genricQueryRepository, IGenricCommandRepository<UserImageModel> genricCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            _httpContextAccessor = httpContextAccessor;
            _genricQueryRepository = genricQueryRepository;
            _genricCommandRepository = genricCommandRepository;
        }

        public async Task<string> Handle(UplodeUserImageCommand request, CancellationToken cancellationToken)
        {

            var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserId))
                return "کاربر احراز هویت نشده است.";

            // 1. ذخیره فایل در سرور
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{request.ImageFile.FileName}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await request.ImageFile.CopyToAsync(fileStream, cancellationToken);
            }

            // 2. بررسی وجود رکورد
            var existing = await _genricQueryRepository.GetByIdAsync(request.UserId);
                                          

            if (existing != null)
            {
                existing.SetPath($"/uploads/{uniqueFileName}");
                await _genricCommandRepository.Update(existing);
            }
            else
            {
                var newEntity = new UserImageModel($"/uploads/{uniqueFileName}", request.UserId);
                await _genricCommandRepository.Add(newEntity);
                existing = newEntity;
            }

            await _unitOfWork.SaveChangeAsync();
            return existing.FilePath; 
        }
    }
}
