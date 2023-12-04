using InventoryConsoleVer.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace InventoryConsoleVer
{
    internal class Full_Items
    {
        static Full_Items()
        {
            GenerateFullItems();
        }
        public static int InventoryCapacity { get; private set; } = 20;

        static public List<Inventory_Item> Itemss;

        static void GenerateFullItems()
        {
            Itemss = new List<Inventory_Item>();

            
            Itemss.AddRange(common_Items.Cast<Inventory_Item>().ToList());

            Itemss.AddRange(uncommon_Items.Cast<Inventory_Item>().ToList());

            Itemss.AddRange(rare_Item.Cast<Inventory_Item>().ToList());

            Itemss.AddRange(epic_Item.Cast<Inventory_Item>().ToList());

            Itemss.AddRange(legendary_Item.Cast<Inventory_Item>().ToList());

        }
        public static void UpdateInventoryCapacity(int playerLevel)
        {
            // Увеличиваем максимальный размер инвентаря каждые 5 уровней героя
            InventoryCapacity = 20 + (playerLevel / 5) * 5;
        }



        static public List<Common_Item> common_Items = new List<Common_Item>
        {
            new Common_Item{ Id = 0, Name = "Мачете", Type = "Меч" },
            new Common_Item { Id = 1, Name = "Меч", Type = "Меч" },
            new Common_Item { Id = 2, Name = "Щит", Type = "Щит" }, 
            new Common_Item { Id = 3, Name = "Лук", Type = "Лук" },
            new Common_Item { Id = 4, Name = "Кинжал", Type = "Оружие" },
            new Common_Item { Id = 5, Name = "Мантия", Type = "Доспех" },
            new Common_Item { Id = 6, Name = "Пояс", Type = "Доспех" },
            new Common_Item { Id = 7, Name = "Шляпа", Type = "Головной убор" },
            new Common_Item { Id = 8, Name = "Кольцо", Type = "Украшение" },
            new Common_Item { Id = 9, Name = "Сапоги", Type = "Обувь" },
            new Common_Item { Id = 10, Name = "Наплечники", Type = "Доспех" },
            new Common_Item { Id = 11, Name = "Перчатки", Type = "Доспех" },
            new Common_Item { Id = 12, Name = "Ожерелье", Type = "Украшение" },
            new Common_Item { Id = 13, Name = "Кольчуга", Type = "Доспех" },
            new Common_Item { Id = 14, Name = "Щит", Type = "Щит" },
            new Common_Item { Id = 15, Name = "Копье", Type = "Оружие" },
            new Common_Item { Id = 16, Name = "Посох", Type = "Посох" },
            new Common_Item { Id = 17, Name = "Капюшон", Type = "Головной убор" },
            new Common_Item { Id = 18, Name = "Кольцо", Type = "Украшение" },
            new Common_Item { Id = 19, Name = "Брюки", Type = "Доспех" },
            new Common_Item { Id = 20, Name = "Ножны", Type = "Доспех" }
        };

        static public List<Uncommon_Item> uncommon_Items = new List<Uncommon_Item>
        {
            new Uncommon_Item { Id = 21, Name = "Заточенный Клинок", Type = "Меч" },
            new Uncommon_Item { Id = 22, Name = "Сверкающий Щит", Type = "Щит" },
            new Uncommon_Item { Id = 23, Name = "Лук Лесного Странника", Type = "Лук" },
            new Uncommon_Item { Id = 24, Name = "Острокогтевой Кинжал", Type = "Меч" },
            new Uncommon_Item { Id = 25, Name = "Облачение Теней", Type = "Доспех" },
            new Uncommon_Item { Id = 26, Name = "Плетеный Пояс", Type = "Доспех" },
            new Uncommon_Item { Id = 27, Name = "Шляпа Скорпида", Type = "Головной убор" },
            new Uncommon_Item { Id = 28, Name = "Кольцо Вечного Огня", Type = "Украшение" },
            new Uncommon_Item { Id = 29, Name = "Сапоги Бескрайних Пустошей", Type = "Обувь" },
            new Uncommon_Item { Id = 30, Name = "Наплечники Иссеченных Крыльев", Type = "Доспех" },
            new Uncommon_Item { Id = 31, Name = "Перчатки Молниеносного Разума", Type = "Доспех" },
            new Uncommon_Item { Id = 32, Name = "Ожерелье Вечной Звезды", Type = "Украшение" },
            new Uncommon_Item { Id = 33, Name = "Кольчуга Забытого Героя", Type = "Доспех" },
            new Uncommon_Item { Id = 34, Name = "Спрятанный Щит", Type = "Щит" },
            new Uncommon_Item { Id = 35, Name = "Копье Сокрушения", Type = "Оружие" },
            new Uncommon_Item { Id = 36, Name = "Посох Мудрости", Type = "Посох" },
            new Uncommon_Item { Id = 37, Name = "Капюшон Черного Ворона", Type = "Головной убор" },
            new Uncommon_Item { Id = 38, Name = "Кольцо Изумрудного Света", Type = "Украшение" },
            new Uncommon_Item { Id = 39, Name = "Брюки Невидимой Угрозы", Type = "Доспех" },
            new Uncommon_Item { Id = 40, Name = "Ножны Живого Дерева", Type = "Доспех" }


            
        };

        static public List<Rare_Item> rare_Item = new List<Rare_Item>
        {
            new Rare_Item {Id = 41, Name = "Покров выбранного возрождения", Type = "Доспех"},
            new Rare_Item { Id = 42, Name = "Железный жезл с сердечником из Скверны", Type = "Посох" },
            new Rare_Item { Id = 43, Name = "Лук священных костей", Type = "Лук" },
            new Rare_Item { Id = 44, Name = "Огнестрел адского цветка", Type = "Огнестрел" },
            new Rare_Item { Id = 45, Name = "Рокочущий большой меч мастера клинка", Type = "Меч" },
            new Rare_Item { Id = 46, Name = "Рубиновый бастион огня Скверны", Type = "Щит" },
            new Rare_Item { Id = 47, Name = "Эгида спасения", Type = "Щит" },
            new Rare_Item { Id = 48, Name = "Шлем странствующего рыцаря", Type = "Головной Убор" },
            new Rare_Item { Id = 49, Name = "Маска злобного фумигатора", Type = "Головной Убор" },
            new Rare_Item { Id = 50, Name = "Оскверненная печать верховного друида", Type = "Украшение" },
           
        };
        static public List<Epic_Item> epic_Item = new List<Epic_Item>
        {
            new Epic_Item { Id = 51, Name = "Эльфбар (10000)тяжек", Type = "Украшение"},
            new Epic_Item { Id = 52, Name = "Тетрадь Смеха", Type = "Оружие"},
            new Epic_Item { Id = 53, Name = "Азим(Повелитель Форточки)", Type = "Оружие" },
            new Epic_Item { Id = 54, Name = "Мешапы с Фреди Фазбером", Type = "Оружие" },
            new Epic_Item { Id = 60, Name = "Линзы Слепошарого дракона", Type = "Украшение" },

        };

        static public List<Legendary_Item> legendary_Item = new List<Legendary_Item>
        {
            new Legendary_Item { Id = 61, Name = "Кольцо Вонголы", Type = "Украшение"},
            new Legendary_Item { Id = 62, Name = "X-Banner", Type = "Оружие" },
            new Legendary_Item { Id = 63, Name = "Шигури Кентоки", Type = "Меч" },
            new Legendary_Item { Id = 64, Name = "Релься", Type = "Лук" },
            new Legendary_Item { Id = 65, Name = "Гнев Дракона, вечный покой Таресгосы", Type = "Посох" }



        };



    }
}
