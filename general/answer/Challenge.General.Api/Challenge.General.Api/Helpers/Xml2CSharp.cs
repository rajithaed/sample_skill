/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */

using System.Collections.Generic;
using System.Xml.Serialization;

namespace Challenge.General.Api.Helpers
{
    [XmlRoot(ElementName = "Header")]
    public class Header
    {
        [XmlElement(ElementName = "ExtractDate")]
        public string ExtractDate { get; set; }
        [XmlElement(ElementName = "ItemCount")]
        public string ItemCount { get; set; }
        [XmlElement(ElementName = "ReturnCode")]
        public string ReturnCode { get; set; }
    }

    [XmlRoot(ElementName = "Scores")]
    public class Scores
    {
        [XmlElement(ElementName = "Hygiene")]
        public string Hygiene { get; set; }
        [XmlElement(ElementName = "Structural")]
        public string Structural { get; set; }
        [XmlElement(ElementName = "ConfidenceInManagement")]
        public string ConfidenceInManagement { get; set; }
    }

    [XmlRoot(ElementName = "Geocode")]
    public class Geocode
    {
        [XmlElement(ElementName = "Longitude")]
        public string Longitude { get; set; }
        [XmlElement(ElementName = "Latitude")]
        public string Latitude { get; set; }
    }

    [XmlRoot(ElementName = "EstablishmentDetail")]
    public class EstablishmentDetail
    {
        [XmlElement(ElementName = "FHRSID")]
        public string FHRSID { get; set; }
        [XmlElement(ElementName = "LocalAuthorityBusinessID")]
        public string LocalAuthorityBusinessID { get; set; }
        [XmlElement(ElementName = "BusinessName")]
        public string BusinessName { get; set; }
        [XmlElement(ElementName = "BusinessType")]
        public string BusinessType { get; set; }
        [XmlElement(ElementName = "BusinessTypeID")]
        public string BusinessTypeID { get; set; }
        [XmlElement(ElementName = "AddressLine1")]
        public string AddressLine1 { get; set; }
        [XmlElement(ElementName = "AddressLine2")]
        public string AddressLine2 { get; set; }
        [XmlElement(ElementName = "AddressLine3")]
        public string AddressLine3 { get; set; }
        [XmlElement(ElementName = "PostCode")]
        public string PostCode { get; set; }
        [XmlElement(ElementName = "RatingValue")]
        public string RatingValue { get; set; }
        [XmlElement(ElementName = "RatingKey")]
        public string RatingKey { get; set; }
        [XmlElement(ElementName = "LocalAuthorityCode")]
        public string LocalAuthorityCode { get; set; }
        [XmlElement(ElementName = "LocalAuthorityName")]
        public string LocalAuthorityName { get; set; }
        [XmlElement(ElementName = "LocalAuthorityWebSite")]
        public string LocalAuthorityWebSite { get; set; }
        [XmlElement(ElementName = "LocalAuthorityEmailAddress")]
        public string LocalAuthorityEmailAddress { get; set; }
        [XmlElement(ElementName = "Scores")]
        public Scores Scores { get; set; }
        [XmlElement(ElementName = "SchemeType")]
        public string SchemeType { get; set; }
        [XmlElement(ElementName = "NewRatingPending")]
        public string NewRatingPending { get; set; }
        [XmlElement(ElementName = "Geocode")]
        public Geocode Geocode { get; set; }
        [XmlElement(ElementName = "AddressLine4")]
        public string AddressLine4 { get; set; }
        [XmlElement(ElementName = "RatingDate")]
        public RatingDate RatingDate { get; set; }
    }

    [XmlRoot(ElementName = "RatingDate")]
    public class RatingDate
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }

    [XmlRoot(ElementName = "EstablishmentCollection")]
    public class EstablishmentCollection
    {
        [XmlElement(ElementName = "EstablishmentDetail")]
        public List<EstablishmentDetail> EstablishmentDetail { get; set; }
    }

    [XmlRoot(ElementName = "FHRSEstablishment")]
    public class FHRSEstablishment
    {
        [XmlElement(ElementName = "Header")]
        public Header Header { get; set; }
        [XmlElement(ElementName = "EstablishmentCollection")]
        public EstablishmentCollection EstablishmentCollection { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
    }

}
