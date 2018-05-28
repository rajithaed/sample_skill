using System.Collections.Generic;
using Challenge.General.Api.Models;
using Challenge.General.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Challenge.General.Api.Controllers
{
    [Route("api/[controller]")]
    public class FootballController : Controller
    {
        private readonly List<FootballDetail> _footballDetails;
        private readonly IFootballService _footballService;

        public FootballController(IFootballService footballServiceService)
        {
            _footballService = footballServiceService;
            _footballDetails = _footballService.FootBallDetails;
        }

        [HttpGet]
        [Route("healthcheck")]
        public OkResult HealthCheck()
        {
            return Ok();
        }


        /// <summary>
        ///     Get all the team names.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("teamnames")]
        public IActionResult GetTeamNames()
        {
            var result = _footballService.GetTeamNames(_footballDetails);
            return Content(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        ///     Get matches between the given teams  e.g. Manchester United vs Leeds.
        /// </summary>
        /// <param name="home">The home.</param>
        /// <param name="visitor">The visitor.</param>
        /// <returns></returns>
        [HttpGet("matchesbetweenteams/{home}/{visitor}")]
        public IActionResult GetMatchesBetween(string home, string visitor)
        {
            var result = _footballService.GetMatchesBetweenTeams(home, visitor, _footballDetails);
            return Content(JsonConvert.SerializeObject(result));
        }

        [HttpGet("matchesbetweenyears/{startyear}/{endyear}")]
        public IActionResult GetMatchesBetweenYears(string startyear, string endyear)
        {
            var result = _footballService.GetMatchesBetweenYears(startyear, startyear, _footballDetails);
            return Content(JsonConvert.SerializeObject(result));
        }
    }
}