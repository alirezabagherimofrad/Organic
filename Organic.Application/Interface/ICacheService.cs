using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Interface
{
    public interface ICacheService
    {
        Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);
        Task<T?> GetAsync<T>(string key);
        Task RemoveAsync(string key);
    }
}
