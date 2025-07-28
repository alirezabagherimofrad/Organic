using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.User
{
    public class UserImageModel
    {
        public UserImageModel(Guid id, string filePath, Guid userId)
        {
            Id = Guid.NewGuid();
            FilePath = filePath;
            UserId = userId;
        }

        public Guid Id { get; set; }

        public string FilePath { get; set; }

        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        private UserImageModel() { }
    }
}
