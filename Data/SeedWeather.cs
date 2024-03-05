using ExperimentNetApi6.Core;

namespace ExperimentNetApi6.Data
{
    public static class SeedWeather
    {
        public static void SeedWeatherRecords() {
            var configuration = AppConfiguration.GetConfigurationBuilder();
            using (var context = new ExperimentNetApi6Context(configuration))
            {
                //creates db if not exists 
                context.Database.EnsureCreated();

                //create entity objects
                var weather1 = new Weather() { DateTime = DateTime.UtcNow, TemperatureC = 19, TemperatureF = 66, Summary = "Hot" };
                var weather2 = new Weather() { DateTime = DateTime.UtcNow, TemperatureC = 20, TemperatureF = 67, Summary = "Hot" };

                //add entitiy to the context
                context.Weather.Add(weather1);
                context.Weather.Add(weather2);

                //save data to the database tables
                context.SaveChanges();

                //retrieve all the students from the database
                foreach (var w in context.Weather)
                {
                    Console.WriteLine($"ID: {w.Id}, Summart: {w.Summary}");
                }
            }
        }
    }
}
