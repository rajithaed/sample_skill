using System;
using System.Collections.Generic;
using System.Linq;
using Challenge.General.Api.Configuration;
using Challenge.General.Api.Models;
using Challenge.General.Api.Services;
using Moq;
using Xunit;

namespace Challenge.General.Tests
{
    public class FootballServiceTests
    {
        public FootballServiceTests()
        {
            var csvPath = "https://raw.githubusercontent.com/jalapic/engsoccerdata/master/data-raw/england.csv";

            var appConfig = new Mock<IApplicationConfiguration>();
            appConfig.Setup(x => x.FootballCsvPath).Returns(csvPath);

            _footballService = new FootballService(appConfig.Object);
        }

        private readonly IFootballService _footballService;

        [Fact]
        public void GivenCsvPath_WhenConvertingFileToObject_ThenReturnsListOfFootballDetails()
        {
            //arrange
            var csvPath = "https://raw.githubusercontent.com/jalapic/engsoccerdata/master/data-raw/england.csv";

            //act
            var result = _footballService.GetFootballDataListFromCsv(csvPath);

            //assert
            Assert.IsType<List<FootballDetail>>(result);
        }

        [Fact]
        public void GivenCsvPath_WhenConvertingFileToObject_ThenReturnsListItemsInString()
        {
            //arrange
            var csvPath = "https://raw.githubusercontent.com/jalapic/engsoccerdata/master/data-raw/england.csv";

            //act
            var result = _footballService.GetFootballDataListFromCsv(csvPath);

            //assert
            Assert.IsType<List<FootballDetail>>(result);
            string expected = "1";
            Assert.Equal(expected, result.First().no);
        }

        [Fact]
        public void GivenFootballDetails_WhenGetTeamNames_ThenReturnsListOfUniqueTeamNames()
        {
            //arrange
            var footballDetails = new List<FootballDetail>()
            {
                new FootballDetail()
                {
                    home = "Man U",
                    visitor = "Chelsea"
                },
                new FootballDetail()
                {
                    home = "Man City",
                    visitor = "Liverpool"
                },
                new FootballDetail()
                {
                    home = "Man City",
                    visitor = "Everton"
                }
            };

            //act
            var result = _footballService.GetTeamNames(footballDetails);

            //assert
            Assert.IsType<List<string>>(result);
            Assert.Equal(5, result.Count);    
        }

        [Fact]
        public void Given2TeamNames_WhenGetMatchesBetweenTeams_ThenReturnsListOfMatcheasBetweenThem()
        {
            //arrange
            var footballDetails = new List<FootballDetail>()
            {
                new FootballDetail()
                {
                    no = "1",
                    home = "Man U",
                    visitor = "Chelsea"
                },
                new FootballDetail()
                {
                    no = "2",
                    home = "Man U",
                    visitor = "Chelsea"
                },
                new FootballDetail()
                {
                    no = "3",
                    home = "Man City",
                    visitor = "Everton"
                }
            };

            string home = "Man U";
            string visitor = "Chelsea";

            //act
            var result = _footballService.GetMatchesBetweenTeams(home, visitor, footballDetails);

            //assert
            Assert.IsType<List<FootballDetail>>(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GivenYearRange_WhenGetMatchesBetweenTheYears_ThenReturnsListOfMatcheasBetweenTheYears()
        {
            //arrange
            var footballDetails = new List<FootballDetail>()
            {
                new FootballDetail()
                {
                    no = "1",
                    home = "Man U",
                    visitor = "Chelsea",
                    Date = new DateTime(2000,2,3).ToString("yyyy-MM-dd")
                },
                new FootballDetail()
                {
                    no = "2",
                    home = "Man U",
                    visitor = "Chelsea",
                    Date = new DateTime(2001,5,3).ToString("yyyy-MM-dd")
                },
                new FootballDetail()
                {
                    no = "3",
                    home = "Man City",
                    visitor = "Everton",
                    Date = new DateTime(2010,1,1).ToString("yyyy-MM-dd")
                }
            };

            string startYear = "2000";
            string endYear = "2005";

            //act
            var result = _footballService.GetMatchesBetweenYears(startYear, endYear, footballDetails);

            //assert
            Assert.IsType<List<FootballDetail>>(result);
            Assert.Equal(2, result.Count);
        }
    }
}