namespace BikeRental.Models
{
    using System;
    using System.Collections.Generic;

    public class Bicycle
    {
        public Bicycle()
        {
            this.Prices = new HashSet<BicyclePrices>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool FrontPage { get; set; }
        public bool Hidden { get; set; }
        public virtual IEnumerable<BicyclePrices> Prices { get; set; }

    }
}