using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL.Models
{
    public partial class Inventory
    {
        [NotMapped]
        public string MakeColor => $"{Make} + ({Color})";

        public override string ToString()
        {
            return $"{PetName ?? "**No Name"} is a {Color} {Make} with Id {CarId}.";
        }
    }
}
