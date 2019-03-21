using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingApp
{
    delegate int BinaryOp(int a, int b);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Synch Delegate Review *****");

            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.",
              Thread.CurrentThread.ManagedThreadId);

            // Invoke Add() in a synchronous manner.
            BinaryOp b = new BinaryOp(Add);

            // Could also write b.Invoke(10, 10);
            var answer = b.BeginInvoke(10, 10, null, null);
            while (!answer.AsyncWaitHandle.WaitOne(1000, true))
            {
                Console.WriteLine("Meanwhile on thread {0}...", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Doing more work in Main()!");
            }
            Console.WriteLine("10 + 10 is {0}.", b.EndInvoke(answer));
            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            // Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.",
              Thread.CurrentThread.ManagedThreadId);

            // Pause to simulate a lengthy operation.
            Thread.Sleep(5000);
            return x + y;
        }
        static void ExtractExecutingThread()
        {
            // Get the thread currently
            // executing this method.
            Thread currThread = Thread.CurrentThread;
            Console.WriteLine("Current Thread: {0}", currThread);

            // Obtain the AppDomain hosting the current thread.
            AppDomain ad = Thread.GetDomain();
            Console.WriteLine("App Domain: {0}", Thread.GetDomain());
        }
    }
}
