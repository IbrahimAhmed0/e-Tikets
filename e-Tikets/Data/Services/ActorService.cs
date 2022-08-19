using e_Tikets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_Tikets.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;
        public ActorService(AppDbContext context)
        {
            _context = context; 
        }
        public void Add(Actor actor)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
          var result =  await  _context.Actors.ToListAsync();
          return result;
        }

        public Actor GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Actor Update(int id, Actor actor)
        {
            throw new System.NotImplementedException();
        }
    }
}
