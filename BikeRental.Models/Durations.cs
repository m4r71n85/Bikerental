using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public static class Durations
    {
        private static string[] durations = new string[] { "1 Hour", "2 Hours", "3 Hours", "4 Hours", "All Day", "24 Hours", "48 Hours", "72 Hours", "7 Days" };

        public static string[] All()
        {
            return durations;
        }
    }
}