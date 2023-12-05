using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace InventoryConsoleVer
{
    internal class Baluyus_Ji_Est
    { 
        static public void ShowGreetings()
        {
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            CenterText("Добро пожаловать в приложение!!!");
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            CenterText("Командная Разработка Командного Проекта В Одиночку");
            Console.ResetColor();
            CenterText("");
            Console.WriteLine();
            Thread.Sleep(4000);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            CenterText("ВЫ ГОТОВЫ ??????????");
            Thread.Sleep(2300);
            Console.Clear();

            CenterText("Ну раз не готовы, то вот вам мой говнокод");
            Thread.Sleep(3000);

            Console.Clear();

            CenterText("Ну для начала по классике Хочу представить вам");
            CenterText("   \\o/        \\o/       \\o/        \\o/       \\o/");
            Thread.Sleep(1000);

            CenterText("3");
            Console.Beep(800, 600);
            Thread.Sleep(1000);

            CenterText("2");
            Console.Beep(800, 600);
            Thread.Sleep(1000);

            CenterText("1");
            Console.Beep(800, 600);
            Thread.Sleep(1000);

            CenterText("Сквиртл");
            Thread.Sleep(1200);
            Console.ResetColor();
            Console.Clear();
            ShowPokemon();

        }
        protected static void CenterText(string text)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }

        static void ShowPokemon()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("               _,........__");
            Console.WriteLine("            ,-'            \"`-.");
            Console.WriteLine("          ,'                   `-. ");
            Console.WriteLine("        ,'                        \\ ");
            Console.WriteLine("      ,'                           . ");
            Console.WriteLine("      .'\\               ,\"\".       `");
            Console.WriteLine("     ._.'|             / |  `       \\");
            Console.WriteLine("     |   |            `-.'  ||       `.");
            Console.WriteLine("     |   |            '-._,'||       | \\");
            Console.WriteLine("     .`.,'             `..,'.'       , |`-.");
            Console.WriteLine("     l                       .'`.  _/  |   `.");
            Console.WriteLine("     `-.._'-   ,          _ _'   -\" \\  .     `");
            Console.WriteLine("`.\"\"\"\"\"'-.`-...,---------','         `. `....__.");
            Console.WriteLine(".'        `\"-..___      __,'\\          \\  \\     \\");
            Console.WriteLine("\\_ .          |   `\"\"\"\"'    `.           . \\     \\");
            Console.WriteLine("  `.          |              `.          |  .     L");
            Console.WriteLine("    `.        |`--...________.'.        j   |     |");
            Console.WriteLine("         `--,\\       .            `7\"\"' |  ,      |");
            Console.WriteLine("            ` `      `            /     |  |      |    _,-'\"\"\"`-.");
            Console.WriteLine("             \\ `.     .          /      |  '      |  ,'          `.");
            Console.WriteLine("              \\  v.__  .        '       .   \\    /| /              \\");
            Console.WriteLine("               \\/    `\"\"\\\"\"\"\"\"\"\"`.       \\   \\  /.''                |");
            Console.WriteLine("                `        .        `._ ___,j.  `/ .-       ,---.     |");
            Console.WriteLine("                ,`-.      \\         .\"     `.  |/        j     `    |");
            Console.WriteLine("               /    `.     \\       /         \\ /         |     /    j");
            Console.WriteLine("              |       `-.   7-.._ .          |\"          '         /");
            Console.WriteLine("              |          `./_    `|          |            .     _,");
            Console.WriteLine("              `.           / `----|          |-............`---'");
            Console.WriteLine("                \\          \\      |          |");
            Console.WriteLine("               ,'           )     `.         |");
            Console.WriteLine("                7____,,..--'      /          |");
            Console.WriteLine("                                  `---.__,--.'");
            Thread.Sleep(3000);
            Console.ResetColor();
            Console.Clear();
            
        }



    }
}
