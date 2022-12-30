using System;
using System.Xml.Serialization;

namespace MovieTime.Models
{
    public class PerformanceScheduleRequest
    {
        public string Version { get; set; }
        public string Command { get; set; }
        public int ShowAvailTickets { get; set; }
        public int ShowSale { get; set; }

    }
    [Serializable, XmlRoot(ElementName = "Response")]
    public class ShowSchedule
    {
        [XmlElement("ShowSchedule")]
        public PerformanceScheduleResponse? PerformanceScheduleResponse { get; set; }
    }


    public class PerformanceScheduleResponse
    {

        [XmlElement("FileVersion")]
        public string? FileVersion { get; set; }
        //[XmlElement("RtsVersion")]
        //public string? RtsVersion { get; set; }
        //[XmlElement("LinkPrefix")]
        //public string? LinkPrefix { get; set; }
        //[XmlElement("Tickets")]
        //public Tickets? TicketList { get; set; }
        [XmlElement("Films")]
        public FilmList? FilmList {get; set;}
      //  public Films? FilmsList { get; set; }
        //[XmlElement("AuditoriumInfo")]
        //public AuditoriumInfo? AuditoriumInfoList { get; set; }

    }

    public class Tickets
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? Tax { get; set; }
    }

   //  [XmlType("Films")]
    public class FilmList
    {
        [XmlElement("Film")]
        public Films[] Films { get; set; }
    }
    //[Serializable, XmlRoot(ElementName = "ShowSchedule")]
   // [XmlType("Film")]
    public class Films
    {
        [XmlElement("Title")]
        public string Title { get; set; }
        [XmlElement("Length")]
        public int Length { get; set; }
        [XmlElement("Website")]
        public string? Website { get; set; }
        [XmlElement("FilmCode")]
        public string? FilmCode { get; set; }
        [XmlElement("MtFilmCode")]
        public string? MtFilmCode { get; set; }
        [XmlElement("Shows")]
        public Shows Show { get; set; }

    }

    public class Shows
    {
        public string DT { get; set; }
        public string Aud { get; set; }
        public string ID { get; set; }
        public string? Link { get; set; }
        public int? RE { get; set; }
        public int? Sold { get; set; }
        public int? SO { get; set; }
        public int? SOGen { get; set; }
        public int? LI { get; set; }

    }

    public class AuditoriumInfo
    {
        public  Aud Aud { get; set; }
    }

    public class Aud
    {
        public int Id { get; set; }
    }
}
