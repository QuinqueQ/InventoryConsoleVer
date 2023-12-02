using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryConsoleVer.Items
{
    internal class Legendary_Item: Common_Item
    {
        public Legendary_Item()
        {
            Rarity = "Легендарный";
            Color = ConsoleColor.DarkYellow;
        }
    }
}
