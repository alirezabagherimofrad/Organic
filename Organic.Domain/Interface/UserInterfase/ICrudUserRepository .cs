using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Interface.UserInterfase
{
    public interface ICrudUserRepository : IGenricCommandRepository<UserModel>
    {
        Task<UserModel?> GetByPhoneNumberAndPasswordAsync(string PhoneNumber, string password);

    }
}
