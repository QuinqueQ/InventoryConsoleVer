using System;
using System.Collections.Generic;

namespace InventoryConsoleVer.Items
{
    internal class Inventory_Item : Full_Items
    {
        public ConsoleColor Color;

        public string? Type { get; set; }
        public string? Name { get; set; }
        public string Rarity { get; protected set; }
        public int Item_Level { get; set; }



        public static void AddItemToInventory(Inventory_Item item)
        {
            Itemss.Add(item);
        }

        public void Display()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($" Название: {Name}, Тип: {Type}, Редкость: {Rarity}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
