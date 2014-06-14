using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class ReservedBicycle
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Duration { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? BicycleId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Bicycle Bicycle { get; set; }
    }
}