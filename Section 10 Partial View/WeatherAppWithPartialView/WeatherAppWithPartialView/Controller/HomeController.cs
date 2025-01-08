using Microsoft.AspNetCore.Mvc;
using WeatherAppWithPartialView.Models;

namespace WeatherAppWithPartialView.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            List<City> cities = new List<City>()
           {
               new City{CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  Temprature = 33},
               new City{CityUniqueCode = "NYC", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  Temprature = 60},
               new City{CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  Temprature = 82}
           };

            return View(cities);
        }

        [Route("/weather/{citycode}")]
        public IActionResult CityDetails(string citycode)
        {
            List<City> cities = new List<City>()
           {
               new City{CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  Temprature = 33},
               new City{CityUniqueCode = "NYC", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  Temprature = 60},
               new City{CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  Temprature = 82}
           };

            City? city = cities.FirstOrDefault(x => x.CityUniqueCode == citycode);

            return View(city);
        }
    }

}
