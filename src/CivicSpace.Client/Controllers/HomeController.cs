using Microsoft.AspNetCore.Mvc;

namespace CivicSpace.Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
