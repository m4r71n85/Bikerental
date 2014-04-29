using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public TourType Type { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Schedules { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string DepartureTime { get; set; }
        public string ContactNumber { get; set; }
        public string Notice { get; set; }
        public decimal OnlinePrice { get; set; }
        public decimal OnstatePrice { get; set; }
        public bool Enabled { get; set; }
        public bool RightPanel { get; set; }
        public bool HomePage { get; set; }
        public bool FrontPage { get; set; }
    }
}