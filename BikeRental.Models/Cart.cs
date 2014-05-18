using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class Cart
    {
        private ICollection<ReservedBicycle> bicycles;
        private ICollection<ReservedTour> tour;
        public int Id { get; set; }
        public string SessionId { get; set; }

        public Cart()
        {
            this.bicycles = new HashSet<ReservedBicycle>();
            this.tour = new HashSet<ReservedTour>();
        }

        public virtual ICollection<ReservedBicycle> ReservedBicycles
        {
            get { return this.bicycles; }
            set { this.bicycles = value; }
        }
        public virtual ICollection<ReservedTour> Tours
        {
            get { return this.tour; }
            set { this.tour = value; }
        }
        public bool Purchased { get; set; }
        public DateTime CreatedAt
        {
            get { return DateTime.Now; }
        }
    }
}