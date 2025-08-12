using Organic.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Interface
{
    public interface IJwtService
    {
        public Task<string> GeneratToken(Guid userId);
    }
}
