using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public static class ImageSizes
    {
        public const string SMALL = "?h=70";
        public const string MEDIUM = "?h=200";
        public const string LARGE = "?h=500";

        public const string FE_SMALL = "?h=50&w=50&mode=crop";
        public const string FE_LARGE = "?h=285&w=285&mode=crop";
        public const string FE_LARGE_RESERVE = "?h=250&w=386&mode=crop";
        public const string FR_LIST_TOURS = "?h=156&w=99&mode=crop";

        public const string FR_QUICK_RESERVE = "?h=115&w=170&mode=crop";
    }
}