using System.Collections.Generic;
using Challenge.General.Api.Models;
using Challenge.General.Api.Models.Results;

namespace Challenge.General.Api.Services
{
    public interface ICountryService
    {
        CountryResult GetCountryName(string isoCode);
        string ConvertToUpperCase(string validIsoCode);
        List<KeyValuePair<string, string>> ConvertJsonToKvp(string jsonStr);
    }
}