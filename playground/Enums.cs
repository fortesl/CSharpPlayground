using System;
using System.Collections.Generic;
using System.Text;

namespace playground
{
    class Enums
    {
        private enum _days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday };

        public static void FunWithEnums()
        {
            Console.WriteLine("Base type: {0}", Enum.GetUnderlyingType(typeof(_days)));

            Console.WriteLine("getname: {0}: {1}", _days.Thursday.ToString(), (byte)_days.Thursday);

            var a = Enum.GetValues(typeof(_days));
            foreach (var item in a)
            {
                Console.WriteLine("{0}: {1}", item.ToString(), item.GetType());
            }

            EvaluateEnum(_days.Thursday);
            Console.ReadLine();
        }


        // This method will print out the details of any enum.
        static private void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Information about {0}", e.GetType());

            Console.WriteLine("Underlying storage type: {0}",
              Enum.GetUnderlyingType(e.GetType()));

            // Get all name-value pairs for incoming parameter.
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);

            // Now show the string name and associated value, using the D format
            // flag (see Chapter 3).
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}",
                  enumData.GetValue(i));
            }
            Console.ReadLine();
        }

    }
}
