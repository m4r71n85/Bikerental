namespace BikeRental.Data.Migrations
{
    using BikeRental.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "BikeRental.Data.DataContext";
        }

        protected override void Seed(DataContext context)
        {
            SeedBicycles(context);
            SeedBicycleTours(context);
        }

        private void SeedBicycleTours(DataContext context)
        {
            //if (!context.BikeTours.Any())
            //{
            //    context.BikeTours.Add(new Models.BikeTour()
            //    {
            //        Name = "Central Park Bike Tour",
            //        Address = "Address",
            //        AllowTimesReservation = "10:00,13:00,16:00",
            //        ContactNumber = "0123",
            //        Description = "Description",
            //        Duration = "24 hours",
            //        Enabled = true,
            //        Image = "image.jpg",
            //        OnlinePrice = 25.00m,
            //        OnstatePrice = 30.00m,
            //        RightPanel = true
            //    });
            //}
        }

        private void SeedBicycles(DataContext context)
        {
            if (!context.Bicycles.Any()) {
                
                context.Bicycles.Add(new Models.Bicycle()
                {
                    Name = "Male Bike",
                    Description = "Adult",
                    Image = "01.jpg",
                    Prices = GetPrices()
                    
                });
                context.Bicycles.Add(new Models.Bicycle()
                {
                    Name = "Female Bike",
                    Description = "Adult",
                    Image = "02.jpg",
                    Prices = GetPrices()
                });
                context.Bicycles.Add(new Models.Bicycle()
                {
                    Name = "Tandem Bike",
                    Description = "Bike Built for 2",
                    Image = "03.jpg",
                    Prices = GetPrices()
                });
                context.Bicycles.Add(new Models.Bicycle()
                {
                    Name = "Kids Bike",
                    Description = "Unisex - Boys & Girls",
                    Image = "04.jpg",
                    Prices = GetPrices()
                });
                context.Bicycles.Add(new Models.Bicycle()
                {
                    Name = "Kids Trailer",
                    Description = "Tag-a-long",
                    Image = "05.jpg",
                    Prices = GetPrices()
                });
                context.Bicycles.Add(new Models.Bicycle()
                {
                    Name = "Baby Seat",
                    Description = "12 Months and Older",
                    Image = "06.jpg",
                    Prices = GetPrices()
                });

            }
        }

        private ICollection<BicyclePrices> GetPrices()
        {
            List<BicyclePrices> prices = new List<BicyclePrices>();
            int counter = 14;
            foreach (string duration in Durations.All())
            {
                prices.Add(new BicyclePrices { Duration = duration, OnlinePrice = counter, OnstatePrice = counter + 6 });
                counter += 4;
            }

            return prices;
        }
    }
}
