
using WeatherSolution.Models;

namespace WeatherSolution.Interface
{
    public interface ICityWeather
    {

        List<CityWeather> GetCityWeatherDetails();

        CityWeather GetCityWehaterDetailsByCityCode(string cityCode);
    }
}
