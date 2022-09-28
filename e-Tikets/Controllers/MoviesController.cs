using e_Tikets.Data;
using e_Tikets.Data.Services;
using e_Tikets.Data.Static;
using e_Tikets.newMovieVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace e_Tikets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllasync(n => n.Cienme);
            return View(allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllasync(n=> n.Cienme);

            if (!string.IsNullOrEmpty(searchString))
            {

                var filterResult = allMovies.Where(n=> n.Name.ToLower().Contains(searchString.ToLower())
                || n.Description.ToLower().Contains(searchString.ToLower()));


                //var filteredREsultNew = allMovies.Where(n => string.Equals(n.Name, searchString,
                //    StringComparison.CurrentCultureIgnoreCase) ||
                //string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filterResult);

            }
            return View("Index", allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Deatails(int id)
        {
            var movieDeatils = await _service.GetMovieByIdAsync(id);
            return View(movieDeatils);
        }
        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownData.Cienmas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(e_Tikets.newMovieVM.NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetNewMovieDropdownsValues();
                ViewBag.Cinemas = new SelectList(movieDropdownData.Cienmas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");
                return View(movieDropdownData);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }


        //GET: Movies/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var movieDeatils = await _service.GetMovieByIdAsync(id);
            if (movieDeatils == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDeatils.Id,
                Name = movieDeatils.Name,
                Description = movieDeatils.Description,
                Price = movieDeatils.Price,
                StartDate = movieDeatils.StartDate,
                EndDate = movieDeatils.EndDate,
                ImageURL = movieDeatils.ImageURL,
                MovieCategory = movieDeatils.MovieCategory,
                CinemaId = movieDeatils.CinemaId,
                ProducerId = movieDeatils.ProducerId,
                ActorIds = movieDeatils.Actor_Movies.Select(n => n.ActorId).ToList(),
            };

            var movieDropdownData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownData.Cienmas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {

            if (id != movie.Id) return View("NotFound");


            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownData.Cienmas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
