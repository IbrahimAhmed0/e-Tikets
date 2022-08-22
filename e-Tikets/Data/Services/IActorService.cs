using e_Tikets.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_Tikets.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAllasync();
        Task <Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);
        Task <Actor> UpdateAsync (int id, Actor newActor);
        Task DeleteAsync(int id);
    }
}
