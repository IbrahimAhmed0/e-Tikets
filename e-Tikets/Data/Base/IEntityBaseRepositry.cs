using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace e_Tikets.Data.Base
{
    public interface IEntityBaseRepositry<T> where T : class , IEntityBase , new()
    {
        Task<IEnumerable<T>> GetAllasync();

        Task<IEnumerable<T>> GetAllasync(params Expression <Func<T, object>>[] includeProperties);

        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
