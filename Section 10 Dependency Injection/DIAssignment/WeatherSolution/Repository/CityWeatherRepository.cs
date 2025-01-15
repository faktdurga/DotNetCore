
using WeatherSolution.Interface;
using WeatherSolution.Models;

namespace WeatherSolution.Repository
{
    public class CityWeatherRepository : ICityWeather

    {
        public List<CityWeather> GetCityWeatherDetails()
        {
            List<CityWeather> cities = new List<CityWeather>
            {
                new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33 },
                new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60 },
                new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82 }
            };

            return cities;
        }

        public CityWeather GetCityWehaterDetailsByCityCode(string cityCode)
        {

            List<CityWeather> cities = new List<CityWeather>
            {
                new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33 },
                new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60 },
                new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82 }
            };

            //get matching city object based on the city code
            CityWeather? city = cities.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();

            return city!;
        }
    }
}
