using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryConsoleVer.Items
{
    internal class Epic_Item: Common_Item
    {
        public Epic_Item()
        {
            Rarity = "Эпический";
            Color = ConsoleColor.Magenta;
        }
    }
}
