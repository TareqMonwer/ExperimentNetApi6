using ExperimentNetApi6.Data;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ExperimentNetApi6.Services
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly ExperimentNetApi6Context _context;

        public WeatherRepository(ExperimentNetApi6Context context)
        {
            _context = context;
        }

        public void CreateWeather()
        {
            _context.Weather.Add(new Weather() { DateTime = DateTime.UtcNow, Summary = "Warm", TemperatureF = 1, TemperatureC = 1, SearchCount = "0" });
            _context.SaveChanges();
        }

        public ICollection<Weather> GetAll()
        {
            return _context.Weather.ToList();
        }

        public Weather GetWeatherById(int id)
        {
            return _context.Weather.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateWeather(int id, Weather weather, WeatherForecast weatherIn)
        {
            weather.Id = id;
            weather.TemperatureF = weatherIn.TemperatureF;
            weather.TemperatureC = weatherIn.TemperatureC;
            weather.DateTime = DateTime.UtcNow;
            weather.SearchCount = weather.SearchCount + 1;
            weather.Summary = weatherIn.Summary;
            _context.Weather.Update(weather);
            _context.SaveChanges();
        }
    }
}