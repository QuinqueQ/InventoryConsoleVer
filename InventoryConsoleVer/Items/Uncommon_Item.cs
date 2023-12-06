using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryConsoleVer.Items
{
    internal class Uncommon_Item : Common_Item
    {
        public Uncommon_Item()
        {
            Rarity = "Необычный";
            Color = ConsoleColor.Green;
            Item_Level = 10;
        }
    }
}
