using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryConsoleVer.Characters
{
    internal class Archer
    {
        public Archer()
        {
            Level = 1;
        }
        public int Level { get; set; }
        public string ValidTypeOfItems { get; set; }

    }
}
