using InventoryConsoleVer.Items;
using System;
using System.Collections.Generic;

internal class Menu
{

    static private int selectedIndex = 0;
    static private Inventory_Item selectedItem;

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
        Console.WriteLine("Выберите класс:\n");

        int selectedClassIndex = 0; // Индекс выбранного класса

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Выбранное имя: {playerName}\n");
            Console.WriteLine("Выберите класс:\n");

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
        Console.WriteLine("*********** MENU ***********");

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
        int itemsPerPage = 10; // Количество предметов на одной странице
        int currentPage = 0; // Текущая страница
        selectedIndex = 0; // Индекс выбранного предмета

        while (true)
        {
            Console.Clear();

            Console.WriteLine($"    Инвентарь (Страница {currentPage + 1}): ");

            int startIndex = currentPage * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, player.Inventory.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray; // Обычный цвет для номера и стрелочки

                if (i == selectedIndex)
                {
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write($"   ");
                }

                Console.Write($"{(i + 1).ToString().PadLeft(2)})"); // Изменено для выравнивания номеров

                Console.ForegroundColor = player.Inventory[i].Color; // Цвет из класса предмета
                Console.WriteLine($"{player.Inventory[i].Name}");

                Console.ResetColor();
            }
            Console.WriteLine($"\nКоличество предметов: {player.Inventory.Count}/{Full_Items.InventoryCapacity}");
            Console.WriteLine("************************************************");
            Console.WriteLine("\nДля выхода в главное меню нажмите Q.");
            Console.WriteLine("Для перехода между страницами используйте ← →");
            Console.WriteLine("Для перемещения вверх используйте ↑");
            Console.WriteLine("Для перемещения вниз используйте ↓");
            Console.WriteLine("Для открытия информации о предмете нажмите Enter");

            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Q)
            {
                return; // Если нажата Q, возвращаемся в главное меню
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
                    currentPage = player.Inventory.Count / itemsPerPage; // Переходим на последнюю страницу, если currentPage стало отрицательным
                    if (player.Inventory.Count % itemsPerPage == 0)
                    {
                        currentPage--; // Корректируем currentPage, если количество предметов делится на itemsPerPage нацело
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
                // Отображение подробной информации о предмете
                ShowItemDetails(player.Inventory[selectedIndex], selectedIndex);
            }
        }
    }



    private static void ShowItemDetails(Inventory_Item item, int currentIndex)
    {
        bool exitMenu = false;

        while (!exitMenu)
        {
            Console.Clear();
            Console.WriteLine($" Информация о предмете:\n ");
            Console.ForegroundColor = item.Color;
            Console.WriteLine($" Название: {item.Name}\n");
            Console.WriteLine($" Тип: {item.Type}\n");
            Console.WriteLine($" Редкость: {item.Rarity}\n");
            Console.ResetColor();
            // Добавьте другие свойства предмета, если необходимо
            Console.WriteLine("\n Для возврата в инвентарь нажмите Q");

            Console.WriteLine("\n Для удаления предмета нажмите D");
            Console.WriteLine(" Для улучшения предмета нажмите U");

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.Q:
                    exitMenu = true;
                    break;
                case ConsoleKey.D:
                    // Добавим подтверждение перед удалением
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
                        // Удаление предмета из инвентаря
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
                    // Улучшение предмета
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
                    // Производим улучшение
                    UpgradeProcess(item, sameRarityItems[selectedIndex]);
                    return;
                case ConsoleKey.Q:
                    // Возврат назад
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
        // Получаем все предметы в порядке увеличения редкости
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

        // Если не удалось выбрать предмет следующей редкости, возвращаем null
        return null;
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
