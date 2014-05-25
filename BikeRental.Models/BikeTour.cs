using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class BikeTour
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string AllowWeekdaysReservation { get; set; }
        public string AllowTimesReservation { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        [Required]
        public string Duration { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        [Required]
        public decimal? OnlinePrice { get; set; }
        [Required]
        public decimal? OnstatePrice { get; set; }
        public bool Enabled { get; set; }
        public bool RightPanel { get; set; }
        public bool HomePage { get; set; }
        public bool WeeklyDeal { get; set; }
    }
}