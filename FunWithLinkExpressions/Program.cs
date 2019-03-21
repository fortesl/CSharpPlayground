﻿using System;
using System.Linq;

namespace FunWithLinkExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Query Expressions *****\n");

            // This array will be the basis of our testing...
            ProductInfo[] itemsInStock = new[] {
                 new ProductInfo{ Name = "Mac's Coffee", Description = "Coffee with TEETH",
              NumberInStock = 24},
                 new ProductInfo{ Name = "Milk Maid Milk", Description = "Milk cow's love",
              NumberInStock = 100},
                 new ProductInfo{ Name = "Pure Silk Tofu", Description = "Bland as Possible",
              NumberInStock = 120},
                 new ProductInfo{ Name = "Crunchy Pops", Description = "Cheezy, peppery goodness",
              NumberInStock = 2},
                 new ProductInfo{ Name = "RipOff Water", Description = "From the tap to your wallet",
              NumberInStock = 100},
                 new ProductInfo{ Name = "Classic Valpo Pizza", Description = "Everyone loves pizza!",
              NumberInStock = 73}
            };

            var items = from product in itemsInStock
                        select product;
            foreach (var prod in items)
            {
                Console.WriteLine(prod.ToString());
            }
            // We will call various methods here!
            Console.ReadLine();
        }
    }

    class ProductInfo
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int NumberInStock { get; set; } = 0;

        public override string ToString()
          => $"Name={Name}, Description={Description}, Number in Stock={NumberInStock}";
    }
}
