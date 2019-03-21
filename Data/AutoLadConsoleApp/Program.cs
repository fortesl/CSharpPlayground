using AutoLadConsoleApp.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AutoLadConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with ADO.NET EF *****\n");
            int carId = AddNewRecord();
            WriteLine(carId);

            PrintAllInventory();
            ReadLine();

        }

        private static int AddNewRecord()
        {
            var car = new Car
            {
                Make = "Honda",
                CarNickName = "Civic",
                Color = "Blue"
            };

            try
            {
                using (var context = new AutoLotEntities())
                {
                    context.Cars.Add(car);

                    context.SaveChanges();
                }
                return car.CarId;
            }
            catch(Exception ex)
            {
                WriteLine(ex.InnerException?.Message);
                return 0;
            }
        }

        private static void PrintAllInventory()
        {
            // Select all items from the Inventory table of AutoLot,
            // and print out the data using our custom ToString() of the Car entity class.
            using (var context = new AutoLotEntities())
            {
                foreach (Car c in context.Cars)
                {
                    WriteLine(c);
                }
            }
        }

    }
}
