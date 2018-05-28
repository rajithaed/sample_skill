using Microsoft.Extensions.Configuration;

namespace Challenge.General.Api.Configuration
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        private readonly IConfiguration _config;

        public ApplicationConfiguration(IConfiguration config)
        {
            _config = config;
        }

        public string CountryEndPoint => _config.GetSection(ConfigKeys.CountryEndPoint).Value;
        public string FootballCsvPath => _config.GetSection(ConfigKeys.FootballCsvPath).Value;
    }
}