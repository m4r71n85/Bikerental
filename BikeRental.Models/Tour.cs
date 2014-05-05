using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class Tour
    {
        public int Id { get; set; }

        [Required]
        public TourType Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }
        public string Description { get; set; }

        [Required]
        public string Duration { get; set; }
        public string Schedules { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string DepartureTime { get; set; }
        public string ContactNumber { get; set; }
        public string Notice { get; set; }

        [Required]
        public decimal? OnlinePrice { get; set; }

        [Required]
        public decimal? OnstatePrice { get; set; }
        public bool Enabled { get; set; }
        public bool RightPanel { get; set; }
        public bool HomePage { get; set; }
        public bool FrontPage { get; set; }
        public bool WeeklyDeal { get; set; }
    }
}