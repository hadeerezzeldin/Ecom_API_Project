using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
         Task <List<T>> GetAllAsync();
        Task<List<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
         Task<T> GetByIdAsync(int id);
        Task<T> GetByIdWithIncludesAsync( int id ,params Expression<Func<T, object>>[] includes);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

    }
}
