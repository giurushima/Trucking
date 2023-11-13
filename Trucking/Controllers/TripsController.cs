using Microsoft.AspNetCore.Mvc;

namespace Trucking.Controllers
{
    public class TripsController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
