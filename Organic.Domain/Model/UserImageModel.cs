using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model
{
    public class UserImageModel
    {
        public Guid Id { get; set; }

        public string FilePath { get; set; }

        public Guid UserId { get; set; }
        public UserModel User { get; set; }
    }
}
