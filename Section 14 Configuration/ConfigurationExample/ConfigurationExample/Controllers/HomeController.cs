using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherAPIOption _configuration;
        public HomeController(IOptions<WeatherAPIOption> configuration)
        {
            _configuration = configuration.Value;
        }


        [Route("/")]
        public IActionResult Index()
        {
            /*
            ViewBag.MyKey = _configuration["MyKey"];
            ViewBag.MyApiKey = _configuration.GetValue("MyApiKey", "No Key defined");
            */
            /*
            ViewBag.ClientID = _configuration["weatherapi:ClientID"];
            ViewBag.ClientSecret = _configuration.GetValue("weatherapi:SecreteKey", "the default client secret");
            */
            /*
            WeatherAPIOption options = _configuration.GetSection("weatherapi").Get<WeatherAPIOption>();

            ViewBag.ClientID = options.ClientId;
            ViewBag.ClientSecret = options.SecreteKey;
            */

            ViewBag.ClientID = _configuration.ClientId;
            ViewBag.ClientSecret = _configuration.SecreteKey;

            return View();
        }
    }
}
