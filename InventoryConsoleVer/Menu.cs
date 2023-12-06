using InventoryConsoleVer.Items;
using System;
using System.Collections.Generic;
using InventoryConsoleVer;
using System.Transactions;

internal class Menu
{

    static private int selectedIndex = 0;

    public static Player player = new Player("", "", 1);

    private enum MenuItem
    {
        Инвентарь = 1,
        Подземелье = 2,
        Выход = 3
    }

    public static void ShowMainMenu(ref string playerName, ref string playerClass, ref int playerLevel)
    {
        //  выбор класса
        ChooseCharacterClass(ref playerClass, ref playerName);

        // Устанавливаем информацию о персонаже
        player.Name = playerName;
        player.Class = playerClass;
        player.Level = playerLevel;

        // основное меню
        ShowMainMenuOptions(ref playerName, ref playerClass, ref playerLevel);
    }

    private static void ChooseCharacterClass(ref string playerClass, ref string playerName)
    {
        Console.WriteLine(" Выберите класс:\n");

        int selectedClassIndex = 0; // Индекс выбранного класса

        while (true)
        {
            Console.Clear();
            Console.WriteLine($" Выбранное имя: {playerName}\n");
            Console.WriteLine(" Выберите класс:\n");

            for (int i = 0; i < 3; i++) 
            {
                Console.BackgroundColor = (selectedClassIndex == i) ? ConsoleColor.White : ConsoleColor.Black;
                Console.ForegroundColor = (selectedClassIndex == i) ? ConsoleColor.Black : ConsoleColor.White;

                Console.WriteLine($" {i + 1}. {(i == 0 ? "Archer" : (i == 1 ? "Warrior" : "Mage"))}");

                Console.ResetColor();
            }

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedClassIndex = (selectedClassIndex - 1 + 3) % 3;
                    break;
                case ConsoleKey.DownArrow:
                    selectedClassIndex = (selectedClassIndex + 1) % 3;
                    break;
                case ConsoleKey.Enter:
                    switch (selectedClassIndex)
                    {
                        case 0:
                            playerClass = "Archer";
                            break;
                        case 1:
                            playerClass = "Warrior";
                            break;
                        case 2:
                            playerClass = "Mage";
                            break;
                    }
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
                case ConsoleKey.L:
                    ChangeLevel(ref playerName, ref playerClass, ref playerLevel, currentMenuItem);
                    break;
                case ConsoleKey.G:
                    GetBasicKit();
                    break;
            }
        }
    }


    private static void EnterDungeon(ref string playerName, ref string playerClass, ref int playerLevel)
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine(" Добро пожаловать в подземелье!\n Готовы ли вы к вызову, Dungeon Master?");
            Console.WriteLine("\n*******************************************************");
            Console.WriteLine(" Нажмите Enter, чтобы начать Квиз.\n Или Q, чтобы выйти");

            ConsoleKeyInfo key = Console.ReadKey(true);
            if(key.Key == ConsoleKey.Q)
            {
                break;
            }    
            if (key.Key == ConsoleKey.Enter)
            {
                Quiz quiz = new Quiz(player);
                quiz.StartQuiz(ref playerLevel);
                Full_Items.UpdateInventoryCapacity(playerLevel);
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

        // добавляем 10 случайных предметов в инвентарь
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
        Console.WriteLine("****************************");

        foreach (var item in Enum.GetValues(typeof(MenuItem)))
        {
            Console.ResetColor();

            if (item.Equals(currentMenuItem))
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"* {item,-20}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"* {item,-20}");
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
                ShowInventory(ref playerLevel);
                break;
            case MenuItem.Подземелье:
                EnterDungeon(ref playerName, ref playerClass, ref playerLevel);
                break;
            case MenuItem.Выход:
                Environment.Exit(0);
                break;
        }
    }

    private static void ShowInventory(ref int playerLevel)
    {
        Console.Clear();
        int itemsPerPage = 10; // Количество предметов на одной странице
        int currentPage = 0; // Текущая страница
        selectedIndex = 0; // Индекс выбранного предмета

        while (true)
        {
            Console.Clear();
            Console.WriteLine("                 Инвентарь");
            Console.WriteLine($"************************************************"); 
            int startIndex = currentPage * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, player.Inventory.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray; // Обычный цвет для номера и стрелочки

                if (i == selectedIndex)
                {
                    Console.Write("->");
                }
                else
                {
                    Console.Write($"  ");
                }

                Console.Write($"{(i + 1).ToString().PadLeft(2)})");

                Console.ForegroundColor = player.Inventory[i].Color; // Цвет из класса предмета
                Console.WriteLine($"{player.Inventory[i].Name}");
                Console.ResetColor();
                
            }
            if (player.Inventory.Count != 0)
                Console.WriteLine("************************************************");

            Console.WriteLine($"");
            Console.WriteLine($" Количество предметов: {player.Inventory.Count}/{Full_Items.InventoryCapacity}  (Страница {currentPage + 1}) ");
            Console.WriteLine("************************************************");
            Console.WriteLine("\nДля выхода в главное меню нажмите Q.");
            Console.WriteLine("Для перехода между страницами используйте <- ->");
            Console.WriteLine("Для перемещения вверх используйте ↑");
            Console.WriteLine("Для перемещения вниз используйте ↓");
            Console.WriteLine("Для открытия информации о предмете нажмите Enter");

            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Q)
            {
                return; 
            }

            if (key.Key == ConsoleKey.RightArrow)
            {
                currentPage++;
                if (currentPage * itemsPerPage >= player.Inventory.Count)
                {
                    currentPage = 0; // Возвращаемся на первую страницу, если превышен лимит
                }

                // Передвигаем курсор на первый элемент новой страницы
                selectedIndex = currentPage * itemsPerPage;
            }

            if (key.Key == ConsoleKey.LeftArrow)
            {
                currentPage--;
                if (currentPage < 0)
                {
                    if (player.Inventory.Count > 0)
                    {
                        currentPage = player.Inventory.Count / itemsPerPage;
                        if (player.Inventory.Count % itemsPerPage == 0)
                        {
                            currentPage--;
                        }
                    }
                    else
                    {
                        currentPage = 0;
                    }
                }

                // Передвигаем курсор на последний элемент новой страницы
                selectedIndex = Math.Min((currentPage + 1) * itemsPerPage - 1, player.Inventory.Count - 1);
            }

            if (key.Key == ConsoleKey.UpArrow && selectedIndex > 0)
            {
                selectedIndex--;
            }
            else if (key.Key == ConsoleKey.DownArrow && selectedIndex < player.Inventory.Count - 1)
            {
                selectedIndex++;
            }

            if (key.Key == ConsoleKey.Enter)
            {
                if(player.Inventory.Count != 0)
                ShowItemDetails(player.Inventory[selectedIndex], selectedIndex, ref playerLevel);
                // Отображение подробной информации о предмете
            }

        }
    }



    private static void ShowItemDetails(Inventory_Item item, int currentIndex, ref int playerLevel)
    {
        bool exitMenu = false;

        while (!exitMenu)
        {
            Console.Clear();
            Console.WriteLine($"      Информация о предмете ");
            Console.WriteLine("**************************************");
            Console.ForegroundColor = item.Color;
            Console.WriteLine($" Название: {item.Name}\n");
            Console.WriteLine($" Тип: {item.Type}\n");
            Console.WriteLine($" Редкость: {item.Rarity}\n");
            Console.WriteLine($" Уровень предмета: {item.Item_Level}");
            if (item.Item_Level > playerLevel)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine($" Вы не можете использовать этот предмет\n         Ваш уровень: {playerLevel}");
                Console.WriteLine("-------------------------------------------");

            }
            Console.ResetColor();
            if ((player.Class == "Warrior" && (item.Type == "Лук" || item.Type == "Посох")) ||
                (player.Class == "Archer" && (item.Type == "Меч" || item.Type == "Посох" || item.Type == "Щит")) ||
                (player.Class == "Mage" && (item.Type == "Лук" || item.Type == "Меч" || item.Type == "Щит")))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($" Вы не можете надеть данное снаряжение\n         Ваш класс {player.Class}");
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
            }

            Console.WriteLine("\n**************************************");
            Console.WriteLine(" Для возврата в инвентарь нажмите Q");
            Console.WriteLine(" Для удаления предмета нажмите D");
            Console.WriteLine(" Для улучшения предмета нажмите U");

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.Q:
                    exitMenu = true;
                    break;
                case ConsoleKey.D:
                    Console.Write($"\nВы уверены, что хотите удалить ");
                    Console.ForegroundColor = item.Color;
                    Console.Write($"{item.Name}");
                    Console.ResetColor();
                    Console.Write("? (Y/N)");
                    ConsoleKeyInfo confirmKey = Console.ReadKey(true);
                    while (confirmKey.Key != ConsoleKey.Y && confirmKey.Key != ConsoleKey.N)
                    {
                        confirmKey = Console.ReadKey(true);
                    }

                    if (confirmKey.Key == ConsoleKey.Y)
                    {
                        player.RemoveItemFromInventory(item);
                        Console.WriteLine($"\nПредмет {item.Name} успешно удален!");
                        exitMenu = true;
                    }
                    else
                    {
                        Console.WriteLine($"\nУдаление предмета {item.Name} отменено.");
                    }
                    break;
                case ConsoleKey.U:
                    UpgradeItem(item, currentIndex);
                    exitMenu = true;
                    break;
            }
        }
    }




    public static Inventory_Item? UpgradeItems(Inventory_Item baseItem, Inventory_Item upgradeItem)
    {
        // Проверяем, что редкость предметов совпадает
        if (baseItem.Rarity == upgradeItem.Rarity)
        {
            // Получаем новый предмет повышенной редкости
            Inventory_Item upgradedItem = GetRandomHigherRarityItem(baseItem.Rarity);

            if (upgradedItem != null)
            {
                return upgradedItem;
            }
        }

        // Если не удалось создать предмет повышенной редкости, возвращаем null
        return null;
    }
    private static void UpgradeItem(Inventory_Item item, int currentIndex)
    {
        Console.Clear();
        Console.WriteLine($" Выберите предмет той же редкости для улучшения {item.Name} (нажмите Q, чтобы вернуться):");

        // Фильтруем предметы той же редкости
        var sameRarityItems = player.Inventory.Where(i => i.Rarity == item.Rarity && i != item).ToList();

        if (sameRarityItems.Count == 0)
        {
            Console.WriteLine(" Нет предметов для улучшения.");
            Console.ReadKey(true);
            return;
        }

        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($" Выберите предмет той же редкости для улучшения {item.Name} (нажмите Q, чтобы вернуться):");

            for (int i = 0; i < sameRarityItems.Count; i++)
            {
                Console.ForegroundColor = sameRarityItems[i].Color;
                if (i == selectedIndex)
                {
                    Console.Write("-> ");
                }
                Console.WriteLine($" {i + 1}. {sameRarityItems[i].Name}");
                Console.ResetColor();
            }

            ConsoleKeyInfo selectionKey = Console.ReadKey(true);

            switch (selectionKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedIndex > 0)
                    {
                        selectedIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (selectedIndex < sameRarityItems.Count - 1)
                    {
                        selectedIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    UpgradeProcess(item, sameRarityItems[selectedIndex]);
                    return;
                case ConsoleKey.Q:
                    return;
            }
        }
    }

    private static void UpgradeProcess(Inventory_Item baseItem, Inventory_Item upgradeItem)
    {
        // Получаем новый предмет повышенной редкости
        Inventory_Item upgradedItem = UpgradeItems(baseItem, upgradeItem);

        if (upgradedItem != null)
        {
            // Удаляем базовый предмет из инвентаря
            player.RemoveItemFromInventory(baseItem);

            // Удаляем предмет для улучшения из инвентаря
            player.RemoveItemFromInventory(upgradeItem);

            // Добавляем новый предмет в инвентарь
            player.AddItemToInventory(upgradedItem);

            Console.Clear();
            Console.WriteLine(" Улучшение завершено!");
            Console.ForegroundColor = baseItem.Color;
            Console.Write($"\n {baseItem.Name} + {upgradeItem.Name}\n");
            Console.ResetColor();
            Console.WriteLine("\n были объединены в ");
            Console.ForegroundColor = upgradedItem.Color;
            Console.Write($"\n {upgradedItem.Name}!");
            Console.ResetColor();

        }
        else
        {
            Console.Clear();
            Console.WriteLine("Не удалось создать предмет повышенной редкости. Улучшение отменено.");
        }

        Console.ReadKey(true);
    }


    public static Inventory_Item? GetRandomHigherRarityItem(string currentRarity)
    {
        List<List<Inventory_Item>> rarityGroups = new List<List<Inventory_Item>>
    {
        Full_Items.common_Items.Cast<Inventory_Item>().ToList(),
        Full_Items.uncommon_Item.Cast<Inventory_Item>().ToList(),
        Full_Items.rare_Item.Cast<Inventory_Item>().ToList(),
        Full_Items.epic_Item.Cast<Inventory_Item>().ToList(),
        Full_Items.legendary_Item.Cast<Inventory_Item>().ToList()
    };

        // Находим индекс текущей редкости
        int currentRarityIndex = rarityGroups.FindIndex(group => group.Any(item => item.Rarity == currentRarity));

        if (currentRarityIndex != -1 && currentRarityIndex < rarityGroups.Count - 1)
        {
            // Выбираем случайный предмет из следующей редкости
            var higherRarityItems = rarityGroups[currentRarityIndex + 1];

            if (higherRarityItems.Count > 0)
            {
                return higherRarityItems[new Random().Next(higherRarityItems.Count)];
            }
        }
        return null;
    }

    private static void ChangeLevel(ref string playerName, ref string playerClass, ref int playerLevel, MenuItem currentMenuItem)
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
                ChangeLevel(ref playerName, ref playerClass, ref playerLevel, currentMenuItem);
            }
            else
            {
                Console.WriteLine("Ошибка ввода уровня. Нажмите любую клавишу для повтора.");
                Console.ReadKey();
                Console.Clear();
                ChangeLevel(ref playerName, ref playerClass, ref playerLevel, currentMenuItem);
            }
        }
    }
    
}
