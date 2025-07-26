using Microsoft.EntityFrameworkCore;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UserInterfase;
using Organic.Domain.Model;
using Organic.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Repositories.UserRepository
{
    public class GetUserQueryRepository : IGetUserQueryRepository
    {
        private readonly DataBaseContext _context;
        public GetUserQueryRepository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }
        public async Task<UserModel?> GetByNationalCode(string nationalCode) =>
            await _context.userModels.FirstOrDefaultAsync(x => x.NationalCode == nationalCode);


        public async Task<UserModel?> GetByPassword(string password) =>
            await _context.userModels.FirstOrDefaultAsync(x => x.Password == password);
    }
}
