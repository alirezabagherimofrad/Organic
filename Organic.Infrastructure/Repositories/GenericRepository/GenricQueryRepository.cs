using Microsoft.EntityFrameworkCore;
using Organic.Domain.Interface;
using Organic.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Repositories.GenericRepository
{
    public class GenricQueryRepository<T> : IGenricQueryRepository<T> where T : class
    {
        private readonly DataBaseContext _context;
        public GenricQueryRepository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        public async Task<List<T>> Getall() =>
            await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T?> GetByIdAsync(Guid Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }
    }
}
