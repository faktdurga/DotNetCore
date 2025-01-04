using Microsoft.AspNetCore.Mvc;

namespace LayoutViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/about-us")]
        public IActionResult About()
        {
            return View();
        }


        [Route("/contact-us")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
