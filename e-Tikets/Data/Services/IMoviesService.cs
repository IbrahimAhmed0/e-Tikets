using e_Tikets.Data.Base;
using e_Tikets.Models;
using e_Tikets.newMovieVM;
using e_Tikets.ViewModels;
using System.Threading.Tasks;

namespace e_Tikets.Data.Services
{
    public interface IMoviesService: IEntityBaseRepositry<Movie>
    {
        Task <Movie> GetMovieByIdAsync(int id);

        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();

        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);



    }
}
