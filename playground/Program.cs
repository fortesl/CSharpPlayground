using System;

namespace playground
{
    class Program
    {

        static void Main(string[] args)
        {
                        Enums.FunWithEnums();

            //   var crs = FunTupling.GetComponentRelationship();
            //   Console.WriteLine("Type: {0}, Existing: {1}", crs.Relation, crs.IsNew);

            var fwd = new FunWithDelegates();

            //fwd.RegisterUsers(WhatUSaid);
            fwd.RegisterUsers2(Add);

            //fwd.DoSomething(8);
            //fwd.DoSomething(12);
            //fwd.DoSomething(17);

            //var fwde = new FunWithDelegateEvents(0);
            //fwde.MealTime += (sender, e) => Console.WriteLine($"Sender: {sender}, message: {e.msg}");

            ////    delegate (object sender, SayThisEventArgs e)
            ////{
            ////    if (sender is FunWithDelegateEvents f)
            ////    {
            ////        Console.WriteLine($"Sender: {sender}, message: {e.msg}");
            ////    }
            ////};

            //fwde.DoSomething(8);
            //Console.WriteLine("hash: {0}", fwde.GetHashCode());
            //var fwde2 = new FunWithDelegateEvents(0);
            //Console.WriteLine("hash2: {0}", fwde2.GetHashCode());

        }

        private static void Fwde_MealTime1(object sender, SayThisEventArgs e)
        {
            if (sender is FunWithDelegateEvents f)
            {
                Console.WriteLine($"Sender: {sender}, message: {e.msg}");
            }
        }

        private static void Fwde_MealTime(string message)
        {
            Console.WriteLine($"{message}");
        }


        public static void WhatUSaid(string message)
        {
            Console.WriteLine($"{message}");
        }

        // Target for the Func<> delegate.
        static int Add(int x, int y)
        {
            return x + y;
        }
    }

    class Animal
    {

    }

    class Dog : Animal
    {

    }

    class Cat : Animal
    {
        public static implicit operator Cat (Dog d) => new Cat();
    }
}
