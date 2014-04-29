using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Data;
using BikeRental.Models;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new DataContext();

            Bicycle bike = new Bicycle()
            {
                Name = "asd",
                Description = "desc",
                FrontPage = false,
                Hidden = false,
                Image = "asdasd.jpg"
            };
            data.Bicycles.Add(bike);
            data.SaveChanges();

            System.Console.WriteLine(data.Bicycles.Count());
        }
    }
}
