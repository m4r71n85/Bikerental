using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class ReservedBikeTour
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? BikeTourId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual BikeTour BikeTour { get; set; }
    }
}