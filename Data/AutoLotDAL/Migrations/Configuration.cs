namespace AutoLotDAL.Migrations
{
    using AutoLotDAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutoLotDAL.EF.AutoLotEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AutoLotDAL.EF.AutoLotEntities context)
        {
            var customers = new List<Customer>
              {
                new Customer {FirstName = "Dave", LastName = "Brenner"},
                new Customer {FirstName = "Matt", LastName = "Walton"},
                new Customer {FirstName = "Steve", LastName = "Hagen"},
                new Customer {FirstName = "Pat", LastName = "Walton"},
                new Customer {FirstName = "Bad", LastName = "Customer"},
              };
            customers.ForEach(x => context.Customers.AddOrUpdate(
              c => new { c.FirstName, c.LastName }, x));

            var cars = new List<Inventory>
              {
                new Inventory {Make = "VW", Color = "Black", PetName = "Zippy"},
                new Inventory {Make = "Ford", Color = "Rust", PetName = "Rusty"},
                new Inventory {Make = "Saab", Color = "Black", PetName = "Mel"},
                new Inventory {Make = "Yugo", Color = "Yellow", PetName = "Clunker"},
                new Inventory {Make = "BMW", Color = "Black", PetName = "Bimmer"},
                new Inventory {Make = "BMW", Color = "Green", PetName = "Hank"},
                new Inventory {Make = "BMW", Color = "Pink", PetName = "Pinky"},
                new Inventory {Make = "Pinto", Color = "Black", PetName = "Pete"},
                new Inventory {Make = "Yugo", Color = "Brown", PetName = "Brownie"},
              };
            context.Inventory.AddOrUpdate(x => new { x.Make, x.Color }, cars.ToArray());

            var orders = new List<Order>
              {
                new Order {Inventory= cars[0], Customer = customers[0]},
                new Order {Inventory= cars[1], Customer = customers[1]},
                new Order {Inventory= cars[2], Customer = customers[2]},
                new Order {Inventory= cars[3], Customer = customers[3]},
              };
            orders.ForEach(x => context.Orders.AddOrUpdate(c => new { c.CarId, c.CustomerId }, x));
            context.CreditRisks.AddOrUpdate(x => new { x.FirstName, x.LastName },
              new CreditRisk
              {
                  FirstName = customers[4].FirstName,
                  LastName = customers[4].LastName,
              }); base.Seed(context);
        }
    }
}
