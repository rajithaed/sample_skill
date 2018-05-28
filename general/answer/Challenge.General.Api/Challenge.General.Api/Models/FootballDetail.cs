using System;

namespace Challenge.General.Api.Models
{
    public class FootballDetail
    {
        public string no { get; set; }
        public string Date { get; set; }
        public string Season { get; set; }
        public string home { get; set; }
        public string visitor { get; set; }
        public string FT { get; set; }
        public string hgoal { get; set; }
        public string vgoal { get; set; }
        public string division { get; set; }
        public string tier { get; set; }
        public string totgoal { get; set; }
        public string goaldif { get; set; }
        public string result { get; set; }
    }
}