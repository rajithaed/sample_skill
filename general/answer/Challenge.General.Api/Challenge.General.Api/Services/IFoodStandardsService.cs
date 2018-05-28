using System.Collections.Generic;
using Challenge.General.Api.Helpers;

namespace Challenge.General.Api.Services
{
    public interface IFoodStandardsService
    {
        List<EstablishmentDetail> GetEstablishmentListFromXml(string xmlFilePath);
        List<EstablishmentDetail> GetTop5ForCleanliness(List<EstablishmentDetail> listOfEstablishments);
        List<EstablishmentDetail> GetBottom5ForCleanliness(List<EstablishmentDetail> listOfEstablishments);
        double GetStarPercentage(List<EstablishmentDetail> listOfEstablishments, string star);
        StarRatings GetStarStarRatings(List<EstablishmentDetail> establishmentList);
    }

    public class StarRatings    
    {
        public string OneStar { get; set; }
        public string  TwoStar { get; set; }
        public string  ThreeStar { get; set; }
        public string  FourStar { get; set; }
        public string  FiveStar { get; set; }
    }
}