namespace BikerRental.Web.Areas.Administration.Models
{
    using BikeRental.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class BicycleDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool FrontPage { get; set; }
        public bool Hidden { get; set; }
        public IEnumerable<BicyclePricesViewModel> Prices { get; set; }

    }
}