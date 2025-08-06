using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Settings
{
    public class MinioSettings
    {
        public string ServiceUrl { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string BucketName { get; set; }
        public string Region { get; set; }
    }
}
