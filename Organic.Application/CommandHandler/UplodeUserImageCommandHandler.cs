using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Organic.Application.Command.User;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Organic.Application.CommandHandler
{
    public class UplodeUserImageCommandHandler : IRequestHandler<UplodeUserImageCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public UplodeUserImageCommandHandler(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public async Task<string> Handle(UplodeUserImageCommand request, CancellationToken cancellationToken)
        {
            var queryRepo = _unitOfWork.QueryRepository<UserImageModel>();
            var commandRepo = _unitOfWork.CommandRepository<UserImageModel>();

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
            var existing = await queryRepo.GetByIdAsync(request.UserId);
                                          

            if (existing != null)
            {
                existing.SetPath($"/uploads/{uniqueFileName}");
                await commandRepo.Update(existing);
            }
            else
            {
                var newEntity = new UserImageModel($"/uploads/{uniqueFileName}", request.UserId);
                await commandRepo.Add(newEntity);
                existing = newEntity;
            }

            await _unitOfWork.SaveChangeAsync();
            return existing.FilePath; // مسیر نسبی ذخیره شده
        }
    }
}
