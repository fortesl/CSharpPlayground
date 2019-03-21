using System;
using System.Linq;

namespace LingOverArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with LINQ to Objects *****\n");
            QueryOverStrings();
            Console.ReadLine();
        }

        static void QueryOverStrings()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = 
                {
                    "Morrowind", "Uncharted 2", "Fallout 3", "Daxter",
                    "System Shock 2"
                };

            //var subset =
            //    currentVideoGames.Where(v => v.Contains(" "));

            var subset2 = from game in currentVideoGames
                         where game.Contains(" ")
                         orderby game descending
                         select game;

            var subset = currentVideoGames
                .Where(g => g.Contains(" "))
                .OrderByDescending(g => g);
//                .Select(g => g);

            foreach (var item in subset)
            {
                Console.WriteLine($"{item}");
            }

            ReflectOverQueryResults(subset2);
            ReflectOverQueryResults(subset, "Extension Methods");

        }

        static void ReflectOverQueryResults(object resultSet, string queryType = "Query Expressions")
        {
            Console.WriteLine($"***** Info about your query using {queryType} *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType());
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName());
        }
    }
}
