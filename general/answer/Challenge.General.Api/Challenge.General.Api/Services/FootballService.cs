using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using Challenge.General.Api.Configuration;
using Challenge.General.Api.Models;

namespace Challenge.General.Api.Services
{
    public class FootballService : IFootballService
    {
        private IApplicationConfiguration _appConfig;
        private List<FootballDetail> _matchDetails;

        public FootballService(IApplicationConfiguration appConfig)
        {
            _appConfig = appConfig;
            _matchDetails = GetFootballDataListFromCsv(appConfig.FootballCsvPath);
            FootBallDetails = _matchDetails;
        }

        public List<FootballDetail> GetFootballDataListFromCsv(string csvPath)
        {
            var footballDetails = new List<FootballDetail>();
            var csvStr = GetCsvString(csvPath);
            var strArray = csvStr.Split('\n');
            var strData = strArray.Skip(1).Select(x => x.Split('\n'));

            var dataList = strData.ToList();
            for (var index = 0; index < dataList.Count - 1; index++)
            {
                var item = dataList[index];
                var parts = item[0].Split(',');
                if (!IsNullOrEmpty(parts))
                {
                    var x = new FootballDetail
                    {
                        no = parts[0].Replace("\"", ""),
                        Date = parts[1].Replace("\"", ""),
                        Season = parts[2].Replace("\"", ""),
                        home = parts[3].Replace("\"", ""),
                        visitor = parts[4].Replace("\"", ""),
                        FT = parts[5].Replace("\"", ""),
                        hgoal = parts[6].Replace("\"", ""),
                        vgoal = parts[7].Replace("\"", ""),
                        division = parts[8].Replace("\"", ""),
                        tier = parts[9].Replace("\"", ""),
                        totgoal = parts[10].Replace("\"", ""),
                        goaldif = parts[11].Replace("\"", ""),
                        result = parts[12].Replace("\"", "")
                    };

                    footballDetails.Add(x);
                }
            }

            return footballDetails;
        }

        public List<string> GetTeamNames(List<FootballDetail> footballDetails)
        {
            var uniqueHomeTeams = footballDetails.Select(x => x.home).Distinct().ToList();
            var uniqueVisitorTeams = footballDetails.Select(x => x.visitor).Distinct().ToList();

            var uniqueTeams = uniqueHomeTeams.Union(uniqueVisitorTeams).ToArray();

            return uniqueTeams.ToList();
        }

        public List<FootballDetail> GetMatchesBetweenTeams(string home, string visitor, List<FootballDetail> footballDetails)
        {
            return footballDetails.Where(x => x.home == home && x.visitor == visitor).ToList();
        }

        public List<FootballDetail> FootBallDetails { get; set; }
        public List<FootballDetail> GetMatchesBetweenYears(string startYear, string endYear, List<FootballDetail> footballDetails)
        {
            var matches = new List<FootballDetail>();
            if (startYear != null && endYear != null && IsDigitsOnly(startYear) && IsDigitsOnly(endYear))
            {
                var start = DateTime.ParseExact(startYear,"yyyy", CultureInfo.InvariantCulture).Year;
                var end = DateTime.ParseExact(endYear, "yyyy", CultureInfo.InvariantCulture).Year;

                foreach (var match in footballDetails)
                {
                    var matchYear = DateTime.ParseExact(match.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture).Year;
                    if (matchYear >= start && matchYear <= end)
                    {
                        matches.Add(match);
                    }
                }
            }
            return matches;
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        public static bool IsNullOrEmpty(Array array)
        {
            return array == null || array.Length == 0;
        }

        public string GetCsvString(string url)
        {
            var req = (HttpWebRequest) WebRequest.Create(url);
            var resp = (HttpWebResponse) req.GetResponse();

            var sr = new StreamReader(resp.GetResponseStream() ?? throw new InvalidOperationException());
            var results = sr.ReadToEnd();
            sr.Close();

            return results;
        }
    }
}