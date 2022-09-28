using e_Tikets.Data;
using e_Tikets.Data.Services;
using e_Tikets.Data.Static;
using e_Tikets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace e_Tikets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCiemas = await _producerService.GetAllasync();
            return View(allCiemas);
        }


        //Get: Actors/ Edit
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id", "FullName", "ProfilePictureURL", "Bio")] Producer newproducer)
        {
            if (!ModelState.IsValid)
            {
                return View(newproducer);
            }
            await _producerService.UpdateAsync(id, newproducer);
            return RedirectToAction(nameof(Index));
        }


        [AllowAnonymous]
        //Get: Producers/ Deatila/ 1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");
            return View(producerDetails);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var producerDetails = await _producerService.GetByIdAsync(id);
            if (producerDetails == null) View("Not Found");

            await _producerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id", "FullName", "ProfilePictureURL", "Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _producerService.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
    }
}
