using Microsoft.EntityFrameworkCore;
using Organic.Domain.Interface.UserInterfase;
using Organic.Domain.Model.User;
using Organic.Infrastructure.Context;
using Organic.Infrastructure.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Repositories.UserRepository
{
    public class CrudUserRepository : GenricCommandRepository<UserModel>, ICrudUserRepository
    {
        private readonly DataBaseContext _context;

        public CrudUserRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserModel?> GetByPhoneNumberAndPasswordAsync(string PhoneNumber, string Password)
        {
            return await _context.userModels.FirstOrDefaultAsync(x => x.PhoneNumber == PhoneNumber && x.Password == Password);
        }
    }
}
