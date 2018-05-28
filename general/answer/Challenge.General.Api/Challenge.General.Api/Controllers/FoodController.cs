using System.Collections.Generic;
using Challenge.General.Api.Helpers;
using Challenge.General.Api.Models.Results;
using Challenge.General.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Challenge.General.Api.Controllers
{
    [Route("api/[controller]")]
    public class FoodController : Controller
    {
        private readonly IFoodStandardsService _foodStandardsService;
        private readonly List<EstablishmentDetail> _establishmentList;

        public FoodController(IFoodStandardsService foodStandardsService)
        {
            _foodStandardsService = foodStandardsService;
            var xmlPath = @"Files\FHRS413en-GB.xml";
            _establishmentList = _foodStandardsService.GetEstablishmentListFromXml(xmlPath);
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
        /// Gets the top 5.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("top5")]
        public IActionResult GetTop5()
        {
            var result = _foodStandardsService.GetTop5ForCleanliness(_establishmentList);
            return Content(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Gets the bottom 5.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("bottom5")]
        public IActionResult GetBottom5()
        {
            var result = _foodStandardsService.GetBottom5ForCleanliness(_establishmentList);
            return Content(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Gets the star percentage.
        /// </summary>
        /// <param name="star">The star.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("percentage")]
        public IActionResult GetPercentage(string star)
        {
            var result = _foodStandardsService.GetStarPercentage(_establishmentList, star);
            return Content(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        [Route("starratingscores")]
        public IActionResult GetStarRatingScores()
        {
            var result = _foodStandardsService.GetStarStarRatings(_establishmentList);
            return Content(JsonConvert.SerializeObject(result));
        }
    }
}