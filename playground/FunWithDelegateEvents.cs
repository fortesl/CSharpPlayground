using System;
using System.Collections.Generic;
using System.Text;

namespace playground
{
    public class SayThisEventArgs : EventArgs
    {
        public readonly string msg;

        public SayThisEventArgs(string message)
        {
            msg = message;
        }
    }

    class FunWithDelegateEvents
    {
        private readonly int _number;
        public FunWithDelegateEvents(int number)
        {
            _number = number;
        }

        public event EventHandler<SayThisEventArgs> MealTime;

        public void DoSomething(int hourOfDay)
        {
            if (hourOfDay < 10)
            {
                MealTime?.Invoke(this, new SayThisEventArgs("Time For breakfast"));
            }
            else if (hourOfDay < 15)
            {
                MealTime?.Invoke(this, new SayThisEventArgs("Have you had lunch yet"));
            }
            else
            {
                MealTime?.Invoke(this, new SayThisEventArgs("Dinner time!!!"));
            }
        }
    }
}
