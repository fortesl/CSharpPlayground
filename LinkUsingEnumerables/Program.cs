﻿using System;
using System.Linq;

namespace LinkUsingEnumerables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        static void QueryStringWithOperators()
        {
            Console.WriteLine("***** Using Query Operators *****");

            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            var subset = from game in currentVideoGames
                         where game.Contains(" ")
                         orderby game
                         select game;

            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        static void QueryStringsWithEnumerableAndLambdas()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};
            // Build a query expression using extension methods
            // granted to the Array via the Enumerable type.
            //The Enumerable.Where() method requires a System.Func<T1, TResult> delegate parameter.
            var subset = currentVideoGames.Where(game => game.Contains(" "))
              .OrderBy(game => game).Select(game => game);

            // Print out the results.
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }
    }
}
