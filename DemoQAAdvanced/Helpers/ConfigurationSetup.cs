using Microsoft.Extensions.Configuration;

namespace DemoQAAdvanced.Helpers
{
    class ConfigurationSetup
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(@"appsettings.json")
                .Build();
            return config;
        }
    }
}
