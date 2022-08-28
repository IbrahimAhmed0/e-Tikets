using e_Tikets.Data.Base;
using e_Tikets.Models;
using System.Threading.Tasks;

namespace e_Tikets.Data.Services
{
    public interface IMoviesService: IEntityBaseRepositry<Movie>
    {
        Task <Movie> GetMovieByIdAsync(int id);
    }
}
