using WeatherSolution.Models;
using Microsoft.AspNetCore.Mvc;
using WeatherSolution.Interface;

namespace WeatherSolution.Controllers
{
    public class WeatherController : Controller
    {

        private readonly ICityWeather _cityWeather;

        public WeatherController(ICityWeather cityWeather)
        {
            _cityWeather= cityWeather;
        }

        //When a HTTP GET request is received at path "/"
        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cities = _cityWeather.GetCityWeatherDetails();
            //send cities collection to "Views/Weather/Index" view
            return View(cities);
        }


        [Route("weather/{cityCode?}")]
        public IActionResult City(string? cityCode)
        {
            //if cityCode is not supplied in the route parameter
            if (string.IsNullOrEmpty(cityCode))
            {
             //send null as model object to "Views/Weather/Index" view
             return View();
            }

            CityWeather city = _cityWeather.GetCityWehaterDetailsByCityCode(cityCode);
            //send matching city object to "Views/Weather/Index" view
            return View(city);
        }
    }
}

