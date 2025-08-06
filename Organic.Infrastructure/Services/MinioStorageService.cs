using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;
using Organic.Application.Interface;
using Organic.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Services
{
    public class MinioStorageService : IFileStorageService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly MinioSettings _settings;

        public MinioStorageService(IOptions<MinioSettings> options)
        {
            _settings = options.Value;

            var config = new AmazonS3Config
            {
                ServiceURL = _settings.ServiceUrl, // مثل "http://localhost:9000" یا "localhost:9000"
                ForcePathStyle = true,
                UseHttp = true, // اگر ServiceURL با http است
                RegionEndpoint = RegionEndpoint.GetBySystemName(_settings.Region)
            };

            _s3Client = new AmazonS3Client(_settings.AccessKey, _settings.SecretKey, config);

        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
        {
            var putRequest = new PutObjectRequest
            {
                BucketName = _settings.BucketName,
                Key = fileName,
                InputStream = fileStream,
                ContentType = "application/octet-stream"
            };

            await _s3Client.PutObjectAsync(putRequest);

            // ساخت URL فایل آپلودشده (فرض بر اینکه public هست یا URL معتبره)
            var fileUrl = $"{_settings.ServiceUrl}/{_settings.BucketName}/{fileName}";
            return fileUrl;
        }
    }
}
