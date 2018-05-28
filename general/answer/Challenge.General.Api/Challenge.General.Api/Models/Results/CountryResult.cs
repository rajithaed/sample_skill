using System.Collections.Generic;
using System.Net;
using Challenge.General.Api.Enums;

namespace Challenge.General.Api.Models.Results
{
    public class CountryResult
    {
        public CountryStatus Status;
        public string CountryName { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}