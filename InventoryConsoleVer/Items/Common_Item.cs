using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InventoryConsoleVer.Items
{
    internal class Common_Item : Inventory_Item
    {
        public static List<Common_Item> Items = new();
        public Common_Item()
        {
            Color = ConsoleColor.White;
            Rarity = "Обычный";
        }

        
    }



}

