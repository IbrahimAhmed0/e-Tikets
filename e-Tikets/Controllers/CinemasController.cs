using e_Tikets.Data;
using e_Tikets.Data.Services;
using e_Tikets.Data.Static;
using e_Tikets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace e_Tikets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemasController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCiemas = await _cinemaService.GetAllasync();
            return View(allCiemas);
        }


        //Get: Actors/ Edit
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null) return View("Not Found");
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, 
            [Bind("Id", "Logo", "Name", "Description")] Cienma newCinema)
        {
            if (!ModelState.IsValid)
            {
                return View(newCinema);
            }
            await _cinemaService.UpdateAsync(id, newCinema);
            return RedirectToAction(nameof(Index));
        }


        [AllowAnonymous]
        //Get: Cienama/ Deatila/ 1
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null) return View("Not Found");
            return View(cinemaDetails);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null) return View("Not Found");
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null) View("Not Found");

            await _cinemaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id", "Logo", "Name", "Description")] Cienma cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _cinemaService.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
    }
}
