using e_Tikets.Data.Base;
using e_Tikets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_Tikets.Data.Services
{
    public class ActorService : EntityBaseReopostery<Actor> , IActorService
    {
        private readonly AppDbContext _context;
        public ActorService(AppDbContext context) : base(context) { }
    }
}
