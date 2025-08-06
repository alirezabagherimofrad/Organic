using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;
using Organic.Application.Interface;
using Organic.Infrastructure.Settings;
using System;
using System.IO;
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
                ServiceURL = _settings.ServiceUrl,
                ForcePathStyle = true,
                UseHttp = _settings.ServiceUrl.StartsWith("http://")
            };
            _s3Client = new AmazonS3Client(_settings.AccessKey, _settings.SecretKey, config);
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
        {
            try
            {
                var putRequest = new PutObjectRequest
                {
                    BucketName = _settings.BucketName,
                    Key = fileName,
                    InputStream = fileStream,
                    ContentType = "application/octet-stream"
                };

                await _s3Client.PutObjectAsync(putRequest);

                // ساخت URL به شکل استاندارد MinIO
                var fileUrl = $"{_settings.ServiceUrl}/{_settings.BucketName}/{fileName}";
                return fileUrl;
            }
            catch (Exception ex)
            {
                // لاگ یا مدیریت خطا
                throw new Exception("Error uploading file to MinIO", ex);
            }
        }
    }
}