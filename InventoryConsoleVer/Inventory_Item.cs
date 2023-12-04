using System;
using System.Collections.Generic;

namespace InventoryConsoleVer
{
    internal class Inventory_Item : Full_Items
    {
        protected ConsoleColor Color;

        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string Rarity { get; protected set; }

        public Inventory_Item()
        {
            Color = ConsoleColor.White;  // Или установите цвет по умолчанию
        }

        public static void AddItemToInventory(Inventory_Item item)
        {
            Itemss.Add(item);
        }

        public void Display()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"ID: {Id}, Название: {Name}, Тип: {Type}, Редкость: {Rarity}");
        }
    }
}
