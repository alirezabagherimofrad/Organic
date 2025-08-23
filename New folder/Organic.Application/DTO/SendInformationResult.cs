using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.DTO
{
    public class SendInformationResult
    {
        public UserModel User { get; set; }
        public string Message { get; set; }
    }
}
