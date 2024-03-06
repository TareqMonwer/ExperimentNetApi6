using ExperimentNetApi6.Data;

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