using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Challenge.General.Api.Helpers;

namespace Challenge.General.Api.Services
{
    public class FoodStandardsService : IFoodStandardsService
    {
        public List<EstablishmentDetail> GetEstablishmentListFromXml(string xmlFilePath)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), xmlFilePath);
            var fileExists = File.Exists(path);
            var extablishmentList = new List<EstablishmentDetail>();

            if (fileExists)
            {
                TextReader txtReader = new StreamReader(path);
                var xmlSerializer = new XmlSerializer(typeof(FHRSEstablishment));
                var doc = (FHRSEstablishment) xmlSerializer.Deserialize(txtReader);
                txtReader.Close();

                extablishmentList = doc.EstablishmentCollection.EstablishmentDetail.ToList();
            }

            return extablishmentList;
        }

        public List<EstablishmentDetail> GetTop5ForCleanliness(List<EstablishmentDetail> listOfEstablishments)
        {
            var top5 = listOfEstablishments.OrderByDescending(x => x.Scores.Hygiene).Take(5).ToList();
            return top5;
        }

        public List<EstablishmentDetail> GetBottom5ForCleanliness(List<EstablishmentDetail> listOfEstablishments)
        {
            var bottom5 = listOfEstablishments.OrderBy(x=>x.Scores.Hygiene).Take(5).ToList();
            return bottom5;
        }

        public double GetStarPercentage(List<EstablishmentDetail> listOfEstablishments, string star)
        {
            var starCount = listOfEstablishments.Where(x => x.RatingValue == star).ToList().Count;
            var percentage = ((double)starCount) / listOfEstablishments.Count * 100;

            return percentage;
        }

        public StarRatings GetStarStarRatings(List<EstablishmentDetail> establishmentList)
        {
            return new StarRatings()
            {
                OneStar = Math.Round(GetStarPercentage(establishmentList, "1"), 2).ToString(CultureInfo.InvariantCulture) + "%",
                TwoStar = Math.Round(GetStarPercentage(establishmentList, "2"), 2).ToString(CultureInfo.InvariantCulture) + "%",
                ThreeStar = Math.Round(GetStarPercentage(establishmentList, "3"), 2).ToString(CultureInfo.InvariantCulture) + "%",
                FourStar = Math.Round(GetStarPercentage(establishmentList, "4"), 2).ToString(CultureInfo.InvariantCulture) + "%",
                FiveStar = Math.Round(GetStarPercentage(establishmentList, "5"), 2).ToString(CultureInfo.InvariantCulture) + "%",
            };
        }
    }
}