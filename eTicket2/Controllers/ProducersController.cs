using eTicket2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket2.Controllers
{
    public class ProducersController : Controller
    {
        // declaring the AppDbContext
        private readonly AppDbContext _context;
        public ProducersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers= await _context.Producers.ToListAsync();
            return View(allProducers);
        }
    }
}
