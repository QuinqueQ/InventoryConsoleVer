using System;
using InventoryConsoleVer.Items;

namespace InventoryConsoleVer
{
    internal class Program
    {

        public static string playerName;
        public static string playerClass;
        public static int playerLevel = 1;

        static void Main()
        {
            //Baluyus_Ji_Est.ShowGreetings();

            GetPlayerInfo();
            Menu.ShowMainMenu(ref playerName, ref playerClass, ref playerLevel);
        }

        private static void GetPlayerInfo()
        {
            Console.Write(" Введите ваше имя: ");
            playerName = Console.ReadLine();
        }
    }
}
