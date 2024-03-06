using ExperimentNetApi6.Data;
using ExperimentNetApi6.Dtos;

namespace ExperimentNetApi6.Services
{
    public interface IWeatherRepository
    {
        void CreateWeather();

        ICollection<Weather> GetAll();

        Weather GetWeatherById(int id);

        void UpdateWeather(int id, Weather weather, WeatherForecast weatherIn);
    }
}