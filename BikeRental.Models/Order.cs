using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class Order
    {
        private ICollection<ReservedBicycle> bicycles;
        private ICollection<ReservedBikeTour> bikeTours;
        private ICollection<ReservedBusTour> busTours;
        public int Id { get; set; }
        public string SessionId { get; set; }

        public Order()
        {
            this.bicycles = new HashSet<ReservedBicycle>();
            this.bikeTours = new HashSet<ReservedBikeTour>();
            this.busTours = new HashSet<ReservedBusTour>();
        }

        public virtual ICollection<ReservedBicycle> ReservedBicycles
        {
            get { return this.bicycles; }
            set { this.bicycles = value; }
        }
        public virtual ICollection<ReservedBikeTour> ReservedBikeTours
        {
            get { return this.bikeTours; }
            set { this.bikeTours = value; }
        }
        public virtual ICollection<ReservedBusTour> ReservedBusTours
        {
            get { return this.busTours; }
            set { this.busTours = value; }
        }
        public int Status { get; set; }
        public string CardType { get; set; }
        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string InvoiceNumber { get; set; }
        public string Desciption { get; set; }
        public string Amount { get; set; }
        public string SecureKey { get; set; }
        public string LocalSecureKey { get; set; }
        public DateTime CreatedAt
        {
            get { return DateTime.Now; }
        }
    }
}