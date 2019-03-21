using System;
using System.Collections.Generic;
using System.Text;

namespace playground
{
    class FunWithDelegates
    {
        private Action<string, int> sayThis;
        private Func<int, int, int> doThis;

        public void RegisterUsers(Action<string, int> method)
        {
            sayThis += method;
        }

        public void RegisterUsers2(Func<int, int, int> method)
        {
            doThis += method;
        }

        public void DoSomething(int hourOfDay)
        {
            if (hourOfDay < 10)
            {
                sayThis("Time For breakfast", hourOfDay);
            }
            else if (hourOfDay < 15)
            {
                sayThis("Have you had lunch yet", hourOfDay);
            }
            else
            {
                sayThis("Dinner time!!!", hourOfDay);
            }
            doThis(10, 100);
        }
    }
}
