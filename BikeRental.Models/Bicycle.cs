namespace BikeRental.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Bicycle
    {
        private ICollection<BicyclePrices> prices;
        private ICollection<ReservedBicycle> reservedBicycle;
        public Bicycle()
        {
            this.prices = new HashSet<BicyclePrices>();
            this.reservedBicycle = new HashSet<ReservedBicycle>();
        }
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Test { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }
        public bool FrontPage { get; set; }
        public bool Hidden { get; set; }
        public virtual ICollection<BicyclePrices> Prices {
            get { return this.prices; }
            set { this.prices = value; }
        }

        public void CreateBicyclePrices(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                this.prices.Add(new BicyclePrices());
            }
        }
    }
}