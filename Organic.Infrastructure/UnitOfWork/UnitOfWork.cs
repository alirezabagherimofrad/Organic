using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Interface.UserInterfase;
using Organic.Infrastructure.Context;
using Organic.Infrastructure.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;

        private readonly Dictionary<Type, object> _repositories = new();
        private readonly IGetUserQueryRepository _userQueryRepository;

        public UnitOfWork(DataBaseContext context, IGetUserQueryRepository userQueryRepository)
        {
            _context = context;
            _userQueryRepository = userQueryRepository;
        }

        public IGenricCommandRepository<T> CommandRepository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repository = new GenricCommandRepository<T>(_context);

                _repositories.Add(typeof(T), repository);
            }

            return (IGenricCommandRepository<T>)_repositories[typeof(T)];
        }

        public IGenricQueryRepository<T> QueryRepository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repository = new GenricQueryRepository<T>(_context);

                _repositories.Add(typeof(T), repository);
            }

            return (IGenricQueryRepository<T>)_repositories[typeof(T)];
        }

        public IGetUserQueryRepository UserQueryRepository()
        {
            return _userQueryRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }


    }
}
