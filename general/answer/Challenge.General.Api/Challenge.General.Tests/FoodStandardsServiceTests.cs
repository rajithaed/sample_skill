using System.Collections.Generic;
using Challenge.General.Api.Helpers;
using Challenge.General.Api.Services;
using Xunit;

namespace Challenge.General.Tests
{
    public class FoodStandardsServiceTests
    {
        public FoodStandardsServiceTests()
        {
            _foodStandardsService = new FoodStandardsService();
        }

        private readonly IFoodStandardsService _foodStandardsService;

        [Fact]
        public void GivenXmlFile_WhenConvertingToObject_ThenReturnsListOfEstablishments()
        {
            //arrange
            const string xmlFilePath = @"Files\FHRS413en-GB.xml";

            //act
            var result = _foodStandardsService.GetEstablishmentListFromXml(xmlFilePath);

            //assert
            Assert.IsType<List<EstablishmentDetail>>(result);
        }

        [Fact]
        public void GivenXmlFile_WhenGetTop5ForClenliness_ThenReturnsTop5()
        {
            //arrange
            const string xmlFilePath = @"Files\FHRS413en-GB.xml";
            var listOfEstablishments = _foodStandardsService.GetEstablishmentListFromXml(xmlFilePath);

            //act
            var result = _foodStandardsService.GetTop5ForCleanliness(listOfEstablishments);

            //assert
            Assert.IsType<List<EstablishmentDetail>>(result);
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void GivenXmlFile_WhenGetBottom5ForClenliness_ThenReturnsBottom5()
        {
            //arrange
            const string xmlFilePath = @"Files\FHRS413en-GB.xml";
            var listOfEstablishments = _foodStandardsService.GetEstablishmentListFromXml(xmlFilePath);

            //act
            var result = _foodStandardsService.GetBottom5ForCleanliness(listOfEstablishments);

            //assert
            Assert.IsType<List<EstablishmentDetail>>(result);
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void GivenXmlFile_WhenGetStarPersentage_ThenReturnsPercentage()
        {
            //arrange
            const string xmlFilePath = @"Files\FHRS413en-GB.xml";
            var listOfEstablishments = _foodStandardsService.GetEstablishmentListFromXml(xmlFilePath);
            var star = "5";

            //act
            var result = _foodStandardsService.GetStarPercentage(listOfEstablishments, star);

            //assert
            Assert.IsType<double>(result);
        }
    }
}