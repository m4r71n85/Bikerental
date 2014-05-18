using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class ReservedTour
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TourType TourType { get; set; }
        public int Male { get; set; }
        public int Female { get; set; }
        public int Children { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TourId { get; set; }
        public virtual Tour Tour { get; set; }
    }
}