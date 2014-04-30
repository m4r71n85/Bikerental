using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikerRental.Web.Areas.Administration.Models
{
    public class BicyclePricesViewModel
    {
        public int Id { get; set; }
        public decimal OnlinePrice { get; set; }
        public decimal OnstatePrice { get; set; }
        public int Duration { get; set; }
        public int BicycleId { get; set; }
    }
}
