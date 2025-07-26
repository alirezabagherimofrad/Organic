using Organic.Domain.Interface;
using Organic.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Repositories.GenericRepository
{
    public class GenricCommandRepository<T> : IGenricCommandRepository<T> where T : class
    {
        private readonly DataBaseContext _context;
        public GenricCommandRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<bool> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(T entity)
        {
             _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
