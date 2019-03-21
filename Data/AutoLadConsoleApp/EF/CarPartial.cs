using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLadConsoleApp.EF
{
    public partial class Car
    {
        public override string ToString()
        {
            return $"{CarNickName ?? "**No Name"} is a {Color} {Make} with Id {CarId}.";
        }
    }
}
