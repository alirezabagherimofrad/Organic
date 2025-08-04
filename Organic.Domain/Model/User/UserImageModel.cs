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
        public UserImageModel(string filePath, Guid userId)
        {
            Id = Guid.NewGuid();
            FilePath = filePath;
            UserId = userId;
        }

        public Guid Id { get; private set; }

        public string FilePath { get; private set; }

        public Guid UserId { get; private set; }
        public UserModel User { get; private set; }

        private UserImageModel() { }


        public void SetPath(string filePath)
        {
            FilePath = filePath;
        }

        public void AddImage(Guid userId, string filePath)
        {
            UserId = userId;
            FilePath = filePath;
        }
    }
}
