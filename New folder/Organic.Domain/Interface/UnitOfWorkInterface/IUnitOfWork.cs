using Organic.Domain.Interface.UserInterfase;
using Organic.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Interface.UnitOfWorkInterface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenricCommandRepository<T> CommandRepository<T>() where T : class;
        IGenricQueryRepository<T> QueryRepository<T>() where T : class;
        IGetUserQueryRepository UserQueryRepository();
        Task<int> SaveChangeAsync();
    }
}
