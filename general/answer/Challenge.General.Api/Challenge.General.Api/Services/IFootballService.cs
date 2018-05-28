using System.Collections.Generic;
using Challenge.General.Api.Models;

namespace Challenge.General.Api.Services
{
    public interface IFootballService
    {
        List<FootballDetail> GetFootballDataListFromCsv(string csvPath);
        List<string> GetTeamNames(List<FootballDetail> footballDetails);
        List<FootballDetail> GetMatchesBetweenTeams(string home, string visitor, List<FootballDetail> footballDetails);
        List<FootballDetail> FootBallDetails { get; set; }
        List<FootballDetail> GetMatchesBetweenYears(string startYear, string endYear, List<FootballDetail> footballDetails);
    }
}