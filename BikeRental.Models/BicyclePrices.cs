﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class BicyclePrices
    {
        public int Id { get; set; }
        public decimal OnlinePrice { get; set; }
        public decimal OnstatePrice { get; set; }
        public int Duration { get; set; }
        public int BicycleId { get; set; }
        public virtual Bicycle Bicycles { get; set; }

    }
}