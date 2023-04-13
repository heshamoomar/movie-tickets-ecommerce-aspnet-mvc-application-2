// controllers are C# classes which inherit from the Controller base class
using eTicket2.Data;
using eTicket2.Data.Services;
using eTicket2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket2.Controllers
{
    public class ActorsController : Controller
    {
        // declaring the AppDbContext
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // for the add new button
        // Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // creating action result of type httppost because we are sending a post request from the create.cshtml
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            // verify if inserted data for a new actor is correct (meets constrains)
            if(ModelState.IsValid)
            {
                return View(actor);
            }
			await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

		// Get: Actors/Edit
		public async Task<IActionResult> Edit(int id)
		{
			var actorDetails = await _service.GetByIdAsync(id);
			if (actorDetails == null) return View("NotFound");
			return View(actorDetails);
		}

		// creating action result of type httppost because we are sending a post request from the create.cshtml
		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
		{
			// verify if inserted data for a new actor is correct (meets constrains)
			if (ModelState.IsValid)
			{
				return View(actor);
			}
			await _service.UpdateAsync(id, actor);
			return RedirectToAction(nameof(Index));
		}

        // Get: Actors/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        // creating action result of type httppost because we are sending a post request from the create.cshtml
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }


    }
}
