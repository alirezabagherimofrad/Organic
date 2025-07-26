using Organic.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Interface.UserInterfase
{
    public interface IGetUserQueryRepository
    {
        Task<UserModel?> GetByNationalCode(string nationalCode);
        Task<UserModel?> GetByPassword(string password);
    }
}
