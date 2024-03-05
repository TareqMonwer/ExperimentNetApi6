namespace ExperimentNetApi6.Data
{
    public class Weather
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string Summary { get; set; }
    }
}