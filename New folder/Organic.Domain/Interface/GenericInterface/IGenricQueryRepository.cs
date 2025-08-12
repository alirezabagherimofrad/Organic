using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Interface
{
    public interface IGenricQueryRepository<T> where T : class
    {
        Task<List<T>> Getall();

        Task<T?> GetByIdAsync(Guid Id);

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
    }
}
