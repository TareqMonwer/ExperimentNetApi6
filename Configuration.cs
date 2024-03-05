namespace ExperimentNetApi6.Core
{
    public static class AppConfiguration
    {
        public static IConfiguration GetConfigurationBuilder()
        {
            // Configuration
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}
