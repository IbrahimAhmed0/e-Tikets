using e_Tikets.Data;
using e_Tikets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace e_Tikets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllasync(n=> n.Cienme);
            return View(allMovies);
        }
        public async Task<IActionResult> Deatails(int id)
        {
            var movieDeatils = await _service.GetMovieByIdAsync(id);
            return View(movieDeatils);
        }
    }
}
