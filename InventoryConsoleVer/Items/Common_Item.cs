using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryConsoleVer.Items
{
    internal class Common_Item
    {

        public List<Common_Item> Items = new();

        protected string Rarity = "Обычный";

        protected ConsoleColor Color = ConsoleColor.White;

        public int Id { get; set; }

        public string? Type { get; set; }
        public string? Name { get; set; }


        public void ShowItems()
        {
            Console.ForegroundColor = Color;
            foreach (Common_Item item in Items)
            {
                if ( item.Type == "Оружие")
                Console.WriteLine($"ID: {item.Id}, Название:{item.Name}, Тип: {item.Type}, Редкость: {item.Rarity}");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
    }



}

