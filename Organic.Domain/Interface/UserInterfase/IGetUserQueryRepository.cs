using Organic.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Interface.UserInterfase
{
    public interface IGetUserQueryRepository : IGenricQueryRepository<UserModel>
    {
        Task<UserModel?> GetByPassword(string password);
        Task<UserModel?> GetByEmail(string email);
        Task<UserModel?> GetById(Guid id);
    }
}
