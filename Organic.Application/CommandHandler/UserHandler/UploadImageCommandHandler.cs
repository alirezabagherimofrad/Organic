using MediatR;
using Organic.Application.Command.User;
using Organic.Application.Interface;
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

        public UploadImageCommandHandler(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        public async Task<string> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            var url = await _fileStorageService.UploadFileAsync(request.ImageStream, request.FileName);
            return url;
        }
    }
}
