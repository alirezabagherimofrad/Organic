using Microsoft.EntityFrameworkCore;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UserInterfase;
using Organic.Domain.Model;
using Organic.Infrastructure.Context;
using Organic.Infrastructure.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Repositories.UserRepository
{
    public class GetUserQueryRepository : GenricQueryRepository<UserModel>, IGetUserQueryRepository
    {
        private readonly DataBaseContext _context;
        public GetUserQueryRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
            _context = dataBaseContext;
        }
        public async Task<UserModel?> GetByPassword(string password) =>
            await _context.userModels.FirstOrDefaultAsync(x => x.Password == password);

        public async Task<UserModel?> GetById(Guid id) => await _context.userModels.FindAsync(id);

        public async Task<UserModel?> GetByEmail(string email) =>
            await _context.userModels.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<UserModel?> GetByPhoneNumber(string phonenumber) =>
            await _context.userModels.FirstOrDefaultAsync(x => x.PhoneNumber == phonenumber);
    }
}
