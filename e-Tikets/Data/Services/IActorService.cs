using e_Tikets.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_Tikets.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();
        Actor GetById(int id);
        void Add(Actor actor);
        Actor Update (int id, Actor actor);
        void Delete(int id);
    }
}
