using InventoryConsoleVer;

internal class Menu
{
    private static List<Inventory_Item> inventory = new();
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
            }
        }
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
        Console.WriteLine("Инвентарь:");

        foreach (Inventory_Item item in Full_Items.Itemss)
        {
            Console.WriteLine();
            item.Display();
        }

        Console.ReadKey(true);
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
        else if (selectedKey.Key == ConsoleKey.Q)
        {
            Console.Clear();
            PrintMenu(currentMenuItem);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Вы ввели неверное значение, попробуйте еще раз");
            Console.ReadKey();
            ShowLevel(ref playerName, ref playerClass, ref playerLevel, currentMenuItem);
        }
    }
}
