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
    public class ActorsController : Controller
    {
        private readonly IActorService _service;

        public ActorsController(IActorService service)
        {
            _service = service;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAllasync();
            return View(allActors);
        }

    

        //Get: Actors/ Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName", "profilePictureURL", "Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
           await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }


        //Get: Actors/ Create

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        [AllowAnonymous]
        //Get: Actors/ Deatila/ 1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetils = await _service.GetByIdAsync(id);
            if (actorDetils == null) return View("Not Found");
            return View(actorDetils);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id , [Bind("Id","FullName", "profilePictureURL", "Bio")] Actor newActor)
        {
            if (!ModelState.IsValid)
            {
                return View(newActor);
            }
            await _service.UpdateAsync(id , newActor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var actorDetilas = await _service.GetByIdAsync(id);
            if(actorDetilas == null) View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
