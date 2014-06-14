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
            SeedBusTours(context);
        }

        private void SeedBusTours(DataContext context)
        {
            if (!context.BusTours.Any())
            {
                context.BusTours.Add(new Models.BusTour()
                {
                    Name = "Downtown Bus Tour",
                    Address = "Address",
                    AllowTimesReservation = "10:00,13:00,16:00",
                    ContactNumber = "0123",
                    Description = "Description",
                    Duration = "10 hours",
                    Enabled = true,
                    Image = "image.jpg",
                    OnlinePrice = 25.00m,
                    OnstatePrice = 30.00m,
                    RightPanel = true,
                });
                context.BusTours.Add(new Models.BusTour()
                {
                    Name = "Uptown Bus Tour",
                    Address = "Address",
                    AllowTimesReservation = "10:00,13:00,16:00",
                    ContactNumber = "0123",
                    Description = "Description",
                    Duration = "10 hours",
                    Enabled = true,
                    Image = "image.jpg",
                    OnlinePrice = 25.00m,
                    OnstatePrice = 30.00m,
                    RightPanel = true,
                });
                context.BusTours.Add(new Models.BusTour()
                {
                    Name = "Night Bus Tour",
                    Address = "Address",
                    AllowTimesReservation = "10:00,13:00,16:00",
                    ContactNumber = "0123",
                    Description = "Description",
                    Duration = "10 hours",
                    Enabled = true,
                    Image = "image.jpg",
                    OnlinePrice = 25.00m,
                    OnstatePrice = 30.00m,
                    RightPanel = true,
                });
                context.BusTours.Add(new Models.BusTour()
                {
                    Name = "Brooklyn Bus Tour",
                    Address = "Address",
                    AllowTimesReservation = "10:00,13:00,16:00",
                    ContactNumber = "0123",
                    Description = "Description",
                    Duration = "10 hours",
                    Enabled = true,
                    Image = "image.jpg",
                    OnlinePrice = 25.00m,
                    OnstatePrice = 30.00m,
                    RightPanel = true,
                });
                context.BusTours.Add(new Models.BusTour()
                {
                    Name = "All City Bus Tour",
                    Address = "Address",
                    AllowTimesReservation = "10:00,13:00,16:00",
                    ContactNumber = "0123",
                    Description = "Description",
                    Duration = "72 hours",
                    Enabled = true,
                    Image = "image.jpg",
                    OnlinePrice = 25.00m,
                    OnstatePrice = 30.00m,
                    RightPanel = true,
                });
            }
        }

        private void SeedBicycleTours(DataContext context)
        {
            if (!context.BikeTours.Any())
            {
                context.BikeTours.Add(new Models.BikeTour()
                {
                    Name = "Central Park Bike Tour",
                    Address = "Address",
                    AllowTimesReservation = "10:00,13:00,16:00",
                    ContactNumber = "0123",
                    Description = "Description",
                    Duration = "10 hours",
                    Enabled = true,
                    Image = "image.jpg",
                    OnlinePrice = 25.00m,
                    OnstatePrice = 30.00m,
                    RightPanel = true,
                    
                });
                context.BikeTours.Add(new Models.BikeTour()
                {
                    Name = "Brooklyn Bike Tour",
                    Address = "Address",
                    AllowTimesReservation = "14:00",
                    ContactNumber = "0123",
                    Description = "Description",
                    Duration = "24 hours",
                    Enabled = true,
                    Image = "image.jpg",
                    OnlinePrice = 25.00m,
                    OnstatePrice = 30.00m,
                    RightPanel = true,

                });
                context.BikeTours.Add(new Models.BikeTour()
                {
                    Name = "New York at Night Bike Tour",
                    Address = "Address",
                    AllowTimesReservation = "19:00",
                    ContactNumber = "0123",
                    Description = "Description",
                    Duration = "8 hours",
                    Enabled = true,
                    Image = "image.jpg",
                    OnlinePrice = 25.00m,
                    OnstatePrice = 30.00m,
                    RightPanel = true,

                });
                context.BikeTours.Add(new Models.BikeTour()
                {
                    Name = "All City Bike Tour",
                    Address = "Address",
                    AllowTimesReservation = "10:00",
                    ContactNumber = "0123",
                    Description = "Description",
                    Duration = "12 hours",
                    Enabled = true,
                    Image = "image.jpg",
                    OnlinePrice = 25.00m,
                    OnstatePrice = 30.00m,
                    RightPanel = true,

                });
                context.BikeTours.Add(new Models.BikeTour()
                {
                    Name = "Harlem Bike Tour",
                    Address = "Address",
                    AllowTimesReservation = "14:00",
                    AllowWeekdaysReservation = "2,4,5,7",
                    ContactNumber = "0123",
                    Description = "Description",
                    Duration = "8 hours",
                    Enabled = true,
                    Image = "image.jpg",
                    OnlinePrice = 25.00m,
                    OnstatePrice = 30.00m,
                    RightPanel = true,

                });
            }
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
