using InventoryConsoleVer;
using System;
using System.Collections.Generic;

internal class Menu
{
    private static Player player = new Player("", "", 1);

    private enum MenuItem
    {
        Инвентарь = 1,
        Уровень = 2,
        Выход = 3
    }

    public static void ShowMainMenu(ref string playerName, ref string playerClass, ref int playerLevel)
    {
        // Первый этап: выбор класса
        ChooseCharacterClass(ref playerClass, ref playerName);

        // Устанавливаем информацию о персонаже
        player.Name = playerName;
        player.Class = playerClass;
        player.Level = playerLevel;

        // Второй этап: основное меню
        ShowMainMenuOptions(ref playerName, ref playerClass, ref playerLevel);
    }

    private static void ChooseCharacterClass(ref string playerClass, ref string playerName)
    {
        Console.WriteLine("Выберите класс:");

        int selectedClassIndex = 0; // Индекс выбранного класса

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Выбранное имя: {playerName}");
            Console.WriteLine("Выберите класс:");

            for (int i = 0; i < 2; i++)
            {
                Console.BackgroundColor = (selectedClassIndex == i) ? ConsoleColor.White : ConsoleColor.Black;
                Console.ForegroundColor = (selectedClassIndex == i) ? ConsoleColor.Black : ConsoleColor.White;

                Console.WriteLine($"{i + 1}. {(i == 0 ? "Archer" : "Warrior")}");

                Console.ResetColor();
            }

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedClassIndex = (selectedClassIndex - 1 + 2) % 2;
                    break;
                case ConsoleKey.DownArrow:
                    selectedClassIndex = (selectedClassIndex + 1) % 2;
                    break;
                case ConsoleKey.Enter:
                    playerClass = (selectedClassIndex == 0) ? "Archer" : "Warrior";
                    return;
            }
        }
    }

    private static void ShowMainMenuOptions(ref string playerName, ref string playerClass, ref int playerLevel)
    {
        MenuItem currentMenuItem = MenuItem.Инвентарь;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"< Имя: {playerName}\n< Класс: {playerClass}\n< Уровень: {playerLevel}");
            PrintMenu(currentMenuItem);

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    ChangeMenuItem(ref currentMenuItem, -1);
                    break;
                case ConsoleKey.DownArrow:
                    ChangeMenuItem(ref currentMenuItem, 1);
                    break;
                case ConsoleKey.Enter:
                    ExecuteMenuItem(ref playerName, ref playerClass, ref playerLevel, currentMenuItem);
                    break;
                case ConsoleKey.G:
                    // Добавляем обработку кнопки "Получить базовый комплект"
                    GetBasicKit();
                    break;
            }
        }
    }

    private static void GetBasicKit()
    {

        // Проверяем, достигнут ли лимит предметов
        if (player.Inventory.Count >= Full_Items.InventoryCapacity)
        {
            Console.Clear();
            Console.WriteLine("Вы достигли лимита предметов!");
            Console.ReadKey(true);
            return;
        }

        // Генерируем и добавляем 10 случайных предметов в инвентарь
        Random random = new Random();
        for (int i = 0; i < 10; i++)
        {
            // Проверяем, достигнут ли лимит предметов после добавления каждого предмета
            if (player.Inventory.Count >= Full_Items.Itemss.Count)
            {
                Console.Clear();
                Console.WriteLine("Вы достигли лимита предметов!");
                Console.ReadKey(true);
                return;
            }

            int randomIndex = random.Next(Full_Items.Itemss.Count);
            Inventory_Item randomItem = Full_Items.Itemss[randomIndex];

            // Проверяем, чтобы не добавить один и тот же предмет дважды
            while (player.Inventory.Contains(randomItem))
            {
                randomIndex = random.Next(Full_Items.Itemss.Count);
                randomItem = Full_Items.Itemss[randomIndex];
            }

            player.AddItemToInventory(randomItem);
        }

        Console.Clear();
        Console.WriteLine("Вы получили базовый комплект!");
        Console.ReadKey(true);
    }

    private static void PrintMenu(MenuItem currentMenuItem)
    {
        Console.WriteLine("***********MENU***********");
        foreach (var item in Enum.GetValues(typeof(MenuItem)))
        {
            Console.ResetColor();
            if (item.Equals(currentMenuItem))
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("* " + item);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("* " + item);
            }
        }

        Console.WriteLine("**************************");
    }

    private static void ChangeMenuItem(ref MenuItem currentMenuItem, int direction)
    {
        int itemCount = Enum.GetValues(typeof(MenuItem)).Length;

        int newMenuItemIndex = ((int)currentMenuItem - 1 + direction + itemCount) % itemCount + 1;
        currentMenuItem = (MenuItem)newMenuItemIndex;
    }

    private static void ExecuteMenuItem(ref string playerName, ref string playerClass, ref int playerLevel, MenuItem currentMenuItem)
    {
        switch (currentMenuItem)
        {
            case MenuItem.Инвентарь:
                ShowInventory();
                break;
            case MenuItem.Уровень:
                ShowLevel(ref playerName, ref playerClass, ref playerLevel, currentMenuItem);
                break;
            case MenuItem.Выход:
                Environment.Exit(0);
                break;
        }
    }

    private static void ShowInventory()
    {
        Console.Clear();
        Console.WriteLine($" Инвентарь:\n Предметов ({player.Inventory.Count}/{Full_Items.InventoryCapacity})");

        int selectedIndex = 0; 

        while (true)
        {
            Console.Clear();

            Console.WriteLine($" Инвентарь:\n Предметов ({player.Inventory.Count}/{Full_Items.InventoryCapacity})");

            for (int i = 0; i < player.Inventory.Count; i++)
            {
                Console.ResetColor();

                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    SetRarityColor(player.Inventory[i].Rarity);
                }
                else
                {
                    SetRarityColor(player.Inventory[i].Rarity);
                }

                Console.WriteLine($"{i + 1}. {player.Inventory[i].Name}");

                Console.ResetColor();
            }

            Console.WriteLine("\nДля выхода в главное меню нажмите 0.");

            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.D0 || key.Key == ConsoleKey.NumPad0)
            {
                return; 
            }

            if (key.Key == ConsoleKey.UpArrow && selectedIndex > 0)
            {
                selectedIndex--;
            }
            else if (key.Key == ConsoleKey.DownArrow && selectedIndex < player.Inventory.Count - 1)
            {
                selectedIndex++;
            }
        }
    }

    private static void SetRarityColor(string rarity)
    {
        switch (rarity.ToLower())
        {
            case "обычный":
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case "необычный":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "редкий":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case "эпический":
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case "легендарный":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
        }
    }

    private static void ShowLevel(ref string playerName, ref string playerClass, ref int playerLevel, MenuItem currentMenuItem)
    {
        Console.Clear();
        Console.WriteLine("Ваш Уровень:" + playerLevel);
        Console.WriteLine("Чтобы Изменить Уровень выберите 1");
        Console.WriteLine("Для Выхода Нажмите Q");
        ConsoleKeyInfo selectedKey = Console.ReadKey(true);

        if (selectedKey.Key == ConsoleKey.D1 || selectedKey.Key == ConsoleKey.NumPad1)
        {
            Console.Clear();
            Console.WriteLine("Введите уровень, который вы хотите:");

            if (int.TryParse(Console.ReadLine(), out int enteredLevel))
            {
                playerLevel = enteredLevel;
                Full_Items.UpdateInventoryCapacity(playerLevel);
                Console.WriteLine("Отлично, для выхода, нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
                ShowLevel(ref playerName, ref playerClass, ref playerLevel, currentMenuItem);
            }
            else
            {
                Console.WriteLine("Ошибка ввода уровня. Нажмите любую клавишу для повтора.");
                Console.ReadKey();
                Console.Clear();
                ShowLevel(ref playerName, ref playerClass, ref playerLevel, currentMenuItem);
            }
        }
    }
}
