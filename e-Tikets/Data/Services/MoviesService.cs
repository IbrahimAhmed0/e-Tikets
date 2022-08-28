using e_Tikets.Data.Base;
using e_Tikets.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace e_Tikets.Data.Services
{
    public class MoviesService: EntityBaseReopostery <Movie> , IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDeatilas = await _context.Movies
                .Include(c => c.Cienme)
                .Include(p => p.Producer)
                .Include(am => am.Actor_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);
            return movieDeatilas;
        }
    }
}
