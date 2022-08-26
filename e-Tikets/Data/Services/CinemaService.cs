using e_Tikets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_Tikets.Data.Services
{
    public class CinemaService : ICinemaService
    {

        private readonly AppDbContext _appDbContext;
        public CinemaService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Cienme>> GetAllasyncCinema()
        {
            var result = await _appDbContext.Cienmes.ToListAsync();
            return result;
        }

        public async Task<Cienme> GetByIdAsyncCinema(int id)
        {
            var result = await _appDbContext.Cienmes.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task AddAsyncCinema(Cienme cinema)
        {
            await _appDbContext.Cienmes.AddAsync(cinema);
            await _appDbContext.SaveChangesAsync();

            
        }

        public async Task<Cienme> UpdateAsyncCinema(int id, Cienme newCinema)
        {
            _appDbContext.Cienmes.Update(newCinema);
            await _appDbContext.SaveChangesAsync();
            return newCinema;

        }

        public async Task DeleteAsyncCinema(int id)
        {
            var removedCinema = await _appDbContext.Cienmes.FirstOrDefaultAsync(c=> c.Id == id);
             _appDbContext.Remove(removedCinema);
            await _appDbContext.SaveChangesAsync();

        }


    }
}
