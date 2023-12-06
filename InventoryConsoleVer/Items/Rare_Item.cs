using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryConsoleVer.Items
{
    internal class Rare_Item: Common_Item
    {
        public Rare_Item()
        {
            Rarity = "Редкий";
            Color = ConsoleColor.Blue;
            Item_Level = 30;
        }
    }
}
