using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_Tikets.Data.Base
{
    public interface IEntityBaseRepositry<T> where T : class , IEntityBase , new()
    {
        Task<IEnumerable<T>> GetAllasync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
