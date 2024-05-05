using Microsoft.AspNetCore.Mvc;

namespace ETickets.PL.Controllers
{
    public class ActorsMoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
