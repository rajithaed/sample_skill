namespace Challenge.General.Api.Configuration
{
    public interface IApplicationConfiguration
    {
        string CountryEndPoint { get; }
        string FootballCsvPath { get; }
    }
}