namespace BikeRental.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Bicycle
    {
        private ICollection<BicyclePrices> prices;
        public Bicycle()
        {
            this.prices = new HashSet<BicyclePrices>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool FrontPage { get; set; }
        public bool Hidden { get; set; }
        public virtual ICollection<BicyclePrices> Prices
        {
            get { return this.prices; }
            set { this.prices = value; }
        }
    }
}