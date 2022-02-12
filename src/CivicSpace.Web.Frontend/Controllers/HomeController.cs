using Microsoft.AspNetCore.Mvc;

namespace CivicSpace.Web.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
