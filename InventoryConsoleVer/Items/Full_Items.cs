using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace InventoryConsoleVer.Items
{
    internal class Full_Items
    {
        static Full_Items()
        {
            GenerateFullItems();
        }
        public static int InventoryCapacity { get; private set; } = 20;

        static public List<Inventory_Item> Itemss;

       public  static void GenerateFullItems()
        {
            Itemss = new List<Inventory_Item>();


            Itemss.AddRange(common_Items.Cast<Inventory_Item>().ToList());

            Itemss.AddRange(uncommon_Item.Cast<Inventory_Item>().ToList());

            Itemss.AddRange(rare_Item.Cast<Inventory_Item>().ToList());

            Itemss.AddRange(epic_Item.Cast<Inventory_Item>().ToList());

            Itemss.AddRange(legendary_Item.Cast<Inventory_Item>().ToList());

        }
        public static void UpdateInventoryCapacity(int playerLevel)
        {
            int additionalCapacity = (playerLevel / 5) * 5;
            InventoryCapacity = 20 + additionalCapacity;
        }



        static public List<Common_Item> common_Items = new List<Common_Item>
        {
            new Common_Item{ Name = "Мачете", Type = "Меч" },
            new Common_Item { Name = "Меч", Type = "Меч" },
            new Common_Item { Name = "Щит", Type = "Щит" },
            new Common_Item { Name = "Лук", Type = "Лук" },
            new Common_Item { Name = "Кинжал", Type = "Оружие" },
            new Common_Item { Name = "Мантия", Type = "Доспех" },
            new Common_Item { Name = "Пояс", Type = "Доспех" },
            new Common_Item { Name = "Шляпа", Type = "Головной убор" },
            new Common_Item { Name = "Кольцо", Type = "Украшение" },
            new Common_Item { Name = "Сапоги", Type = "Обувь" },
            new Common_Item { Name = "Наплечники", Type = "Доспех" },
            new Common_Item { Name = "Перчатки", Type = "Доспех" },
            new Common_Item { Name = "Ожерелье", Type = "Украшение" },
            new Common_Item { Name = "Кольчуга", Type = "Доспех" },
            new Common_Item { Name = "Щит", Type = "Щит" },
            new Common_Item { Name = "Копье", Type = "Оружие" },
            new Common_Item { Name = "Посох", Type = "Посох" },
            new Common_Item { Name = "Капюшон", Type = "Головной убор" },
            new Common_Item { Name = "Кольцо", Type = "Украшение" },
            new Common_Item { Name = "Брюки", Type = "Доспех" },
            new Common_Item { Name = "Ножны", Type = "Доспех" }
        };

        static public List<Uncommon_Item> uncommon_Item = new List<Uncommon_Item>
        {
            new Uncommon_Item { Name = "Заточенный Клинок", Type = "Меч" },
            new Uncommon_Item { Name = "Сверкающий Щит", Type = "Щит" },
            new Uncommon_Item { Name = "Лук Лесного Странника", Type = "Лук" },
            new Uncommon_Item { Name = "Острокогтевой Кинжал", Type = "Меч" },
            new Uncommon_Item { Name = "Облачение Теней", Type = "Доспех" },
            new Uncommon_Item { Name = "Плетеный Пояс", Type = "Доспех" },
            new Uncommon_Item { Name = "Шляпа Скорпида", Type = "Головной убор" },
            new Uncommon_Item { Name = "Кольцо Вечного Огня", Type = "Украшение" },
            new Uncommon_Item { Name = "Сапоги Бескрайних Пустошей", Type = "Обувь" },
            new Uncommon_Item { Name = "Наплечники Иссеченных Крыльев", Type = "Доспех" },
            new Uncommon_Item { Name = "Перчатки Молниеносного Разума", Type = "Доспех" },
            new Uncommon_Item { Name = "Ожерелье Вечной Звезды", Type = "Украшение" },
            new Uncommon_Item { Name = "Кольчуга Забытого Героя", Type = "Доспех" },
            new Uncommon_Item { Name = "Спрятанный Щит", Type = "Щит" },
            new Uncommon_Item { Name = "Копье Сокрушения", Type = "Оружие" },
            new Uncommon_Item { Name = "Посох Мудрости", Type = "Посох" },
            new Uncommon_Item { Name = "Капюшон Черного Ворона", Type = "Головной убор" },
            new Uncommon_Item { Name = "Кольцо Изумрудного Света", Type = "Украшение" },
            new Uncommon_Item { Name = "Брюки Невидимой Угрозы", Type = "Доспех" },
            new Uncommon_Item { Name = "Ножны Живого Дерева", Type = "Доспех" }



        };

        static public List<Rare_Item> rare_Item = new List<Rare_Item>
        {
            new Rare_Item { Name = "Покров выбранного возрождения", Type = "Доспех"},
            new Rare_Item { Name = "Железный жезл с сердечником из Скверны", Type = "Посох" },
            new Rare_Item { Name = "Лук священных костей", Type = "Лук" },
            new Rare_Item { Name = "Огнестрел адского цветка", Type = "Огнестрел" },
            new Rare_Item { Name = "Рокочущий большой меч мастера клинка", Type = "Меч" },
            new Rare_Item { Name = "Рубиновый бастион огня Скверны", Type = "Щит" },
            new Rare_Item { Name = "Эгида спасения", Type = "Щит" },
            new Rare_Item { Name = "Шлем странствующего рыцаря", Type = "Головной Убор" },
            new Rare_Item { Name = "Маска злобного фумигатора", Type = "Головной Убор" },
            new Rare_Item { Name = "Оскверненная печать верховного друида", Type = "Украшение" },

        };
        static public List<Epic_Item> epic_Item = new List<Epic_Item>
        {
            new Epic_Item { Name = "Эльфбар (10000)тяжек", Type = "Украшение"},
            new Epic_Item { Name = "Тетрадь Смеха", Type = "Оружие"},
            new Epic_Item { Name = "Азим(Повелитель Форточки)", Type = "Оружие" },
            new Epic_Item { Name = "Мешапы с Фреди Фазбером", Type = "Оружие" },
            new Epic_Item { Name = "Линзы Слепошарого дракона", Type = "Украшение" },

        };

        static public List<Legendary_Item> legendary_Item = new List<Legendary_Item>
        {
            new Legendary_Item { Name = "Кольцо Вонголы", Type = "Украшение"},
            new Legendary_Item { Name = "X-Banner", Type = "Оружие" },
            new Legendary_Item { Name = "Шигури Кентоки", Type = "Меч" },
            new Legendary_Item { Name = "Релься", Type = "Лук" },
            new Legendary_Item { Name = "Гнев Дракона, вечный покой Таресгосы", Type = "Посох" }



        };

        public static Inventory_Item? GetRandomHigherRarityItem(string currentRarity)
        {
            List<List<Inventory_Item>> rarityGroups = new List<List<Inventory_Item>>
            {
                epic_Item.Cast<Inventory_Item>().ToList(),
                legendary_Item.Cast<Inventory_Item>().ToList()
            };

            foreach (var group in rarityGroups)
            {
                if (group.Any(item => item.Rarity == currentRarity))
                {

                    var higherRarityItems = group.Where(item => item.Rarity != currentRarity).ToList();
                    if (higherRarityItems.Count > 0)
                    {
                        return higherRarityItems[new Random().Next(higherRarityItems.Count)];
                    }
                }
            }


            return null;
        }


    }
}
