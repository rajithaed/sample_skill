using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Challenge.General.Api.Configuration;
using Challenge.General.Api.Enums;
using Challenge.General.Api.Models.Results;
using Newtonsoft.Json;

namespace Challenge.General.Api.Services
{
    public class CountryService : ICountryService
    {
        private readonly IApplicationConfiguration _appConfig;
        private readonly string _jsonString;

        public CountryService(IApplicationConfiguration appConfig)
        {
            _appConfig = appConfig;
            _jsonString = GetListFromEndPoint(_appConfig.CountryEndPoint);
        }

        public CountryResult GetCountryName(string isoCode)
        {
            var result = new CountryResult();
            var isoCodeUpperCase = ConvertToUpperCase(isoCode);

            var countryKvp = ConvertJsonToKvp(_jsonString);

            if (IsValidCode(isoCodeUpperCase, countryKvp))
            {
                result.CountryName = GetName(isoCodeUpperCase, countryKvp);
                result.Status = CountryStatus.Valid;
                result.HttpStatusCode = HttpStatusCode.OK;
            }
            else
            {
                result.Status = CountryStatus.Invalid;
                result.HttpStatusCode = HttpStatusCode.NotFound;
            }

            return result;
        }

        public string ConvertToUpperCase(string isoCode)
        {
            return isoCode.ToUpper();
        }

        public List<KeyValuePair<string, string>> ConvertJsonToKvp(string jsonString)
        {
            var obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            return obj.ToList();
        }

        private string GetListFromEndPoint(string appConfigCountryEndPoint)
        {
            var jsonStr = "";
            using (new WebClient())
            {
                var n = new WebClient();
                var json = n.DownloadString(appConfigCountryEndPoint);
                jsonStr = Convert.ToString(json);
            }

            return jsonStr;
        }

        private string GetName(string isoCodeUpperCase, IEnumerable<KeyValuePair<string, string>> countryKvp)
        {
            return countryKvp.FirstOrDefault(x => x.Key == isoCodeUpperCase).Value;
        }

        private bool IsValidCode(string code, List<KeyValuePair<string, string>> countryKvp)
        {
            var validIsoCodes = GetValidIsoCodes(countryKvp);
            return validIsoCodes.Any(isoCode => code == isoCode);
        }

        private IEnumerable<string> GetValidIsoCodes(List<KeyValuePair<string, string>> countryKvp)
        {
            var validCodes = new List<string>();
            foreach (var item in countryKvp) validCodes.Add(item.Key);
            return validCodes;
        }
    }
}