using Microsoft.AspNetCore.Mvc;

namespace EnviornmentExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("/")]
        [Route("/some-route")]
        public IActionResult Index()
        {
            ViewBag.CurrentEnviornment = _webHostEnvironment.EnvironmentName;
            return View();
        }

        [Route("/some-route")]
        public IActionResult Other()
        {
            return View();
        }
    }
}
