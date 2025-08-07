using MediatR;
using Organic.Application.Command.User;
using Organic.Application.Interface;
using Organic.Domain.Interface;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.UserHandler
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, string>
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IGenricCommandRepository<miniomodel> _minioRepository;
        public UploadImageCommandHandler(IFileStorageService fileStorageService, IGenricCommandRepository<miniomodel> minioRepository)
        {
            _fileStorageService = fileStorageService;
            _minioRepository = minioRepository;
        }

        public async Task<string> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            var url = await _fileStorageService.UploadFileAsync(request.ImageStream, request.FileName);
            return url;
        }
    }
}
