using Challenge.General.Api.Models.Results;
using Challenge.General.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.General.Api.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        /// <summary>
        /// This is a health check probe to see whether the service is working.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("healthcheck")]
        public OkResult HealthCheck()
        {
            return Ok();
        }

        /// <summary>
        /// Gets the specified country name for a given ISO code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        [HttpGet("{code}")]
        public CountryResult Get(string code)
        {
            var result = _countryService.GetCountryName(code);
            return result;
        }
    }
}