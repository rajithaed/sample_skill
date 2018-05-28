using Challenge.General.Api.Configuration;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Challenge.General.Tests
{
    public class ConfigurationTests
    {
        public ConfigurationTests()
        {
            _key = "CountryEndPoint";
            _moqConfig = new Mock<IConfiguration>();
            _applicationConfiguration = new ApplicationConfiguration(_moqConfig.Object);
        }

        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly string _key;
        private readonly Mock<IConfiguration> _moqConfig;

        [Fact]
        public void GivenAConfigurationKey_WhenCallingTheConfigCountryEndPoint_ShouldReturnValue()
        {
            //Arrange
            _moqConfig.Setup(x => x.GetSection(_key).Value).Returns("CountryEndPoint");

            //Act
            var result = _applicationConfiguration.CountryEndPoint;

            //Assert
            Assert.Equal("CountryEndPoint", result);
        }
    }
}