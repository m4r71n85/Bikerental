using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class ReservedBusTour
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //public int Quantity { get; set; }
        public int Adults { get; set; }
        public int Kids { get; set; }
        public decimal Price { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? BusTourId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual BusTour BusTour { get; set; }
        public virtual Order Order { get; set; }
    }
}