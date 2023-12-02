using System;
using InventoryConsoleVer.Items;

namespace InventoryConsoleVer
{
    internal class Program
    {
        static void Main()
        {
            Common_Item common_Items = new();

            common_Items.Items.Add(new Common_Item { Id = 0, Name = "Мачете", Type = "Оружие" });
            common_Items.Items.Add(new Common_Item { Id = 1, Name = "Меч", Type = "Оружие" });
            common_Items.Items.Add(new Common_Item { Id = 2, Name = "Щит", Type = "Щит" });
            common_Items.Items.Add(new Common_Item { Id = 3, Name = "Лук", Type = "Оружие" });
            common_Items.Items.Add(new Common_Item { Id = 4, Name = "Кинжал", Type = "Оружие" });
            common_Items.Items.Add(new Common_Item { Id = 5, Name = "Мантия", Type = "Доспех" });
            common_Items.Items.Add(new Common_Item { Id = 6, Name = "Пояс", Type = "Доспех" });
            common_Items.Items.Add(new Common_Item { Id = 7, Name = "Шляпа", Type = "Головной убор" });
            common_Items.Items.Add(new Common_Item { Id = 8, Name = "Кольцо", Type = "Украшение" });
            common_Items.Items.Add(new Common_Item { Id = 9, Name = "Сапоги", Type = "Обувь" });
            common_Items.Items.Add(new Common_Item { Id = 10, Name = "Наплечники", Type = "Доспех" });
            common_Items.Items.Add(new Common_Item { Id = 11, Name = "Перчатки", Type = "Доспех" });
            common_Items.Items.Add(new Common_Item { Id = 12, Name = "Ожерелье", Type = "Украшение" });
            common_Items.Items.Add(new Common_Item { Id = 13, Name = "Кольчуга", Type = "Доспех" });
            common_Items.Items.Add(new Common_Item { Id = 14, Name = "Щит", Type = "Щит" });
            common_Items.Items.Add(new Common_Item { Id = 15, Name = "Копье", Type = "Оружие" });
            common_Items.Items.Add(new Common_Item { Id = 16, Name = "Посох", Type = "Оружие" });
            common_Items.Items.Add(new Common_Item { Id = 17, Name = "Капюшон", Type = "Головной убор" });
            common_Items.Items.Add(new Common_Item { Id = 18, Name = "Кольцо", Type = "Украшение" });
            common_Items.Items.Add(new Common_Item { Id = 19, Name = "Брюки", Type = "Доспех" });
            common_Items.Items.Add(new Common_Item { Id = 20, Name = "Ножны", Type = "Доспех" });


            Uncommon_Item uncommonItems = new ();
            uncommonItems.Items.Add(new Uncommon_Item { Id = 21, Name = "Заточенный Клинок", Type = "Оружие" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 22, Name = "Сверкающий Щит", Type = "Щит" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 23, Name = "Лук Лесного Странника", Type = "Оружие" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 24, Name = "Острокогтевой Кинжал", Type = "Оружие" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 25, Name = "Облачение Теней", Type = "Доспех" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 26, Name = "Плетеный Пояс", Type = "Доспех" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 27, Name = "Шляпа Скорпида", Type = "Головной убор" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 28, Name = "Кольцо Вечного Огня", Type = "Украшение" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 29, Name = "Сапоги Бескрайних Пустошей", Type = "Обувь" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 30, Name = "Наплечники Иссеченных Крыльев", Type = "Доспех" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 31, Name = "Перчатки Молниеносного Разума", Type = "Доспех" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 32, Name = "Ожерелье Вечной Звезды", Type = "Украшение" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 33, Name = "Кольчуга Забытого Героя", Type = "Доспех" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 34, Name = "Спрятанный Щит", Type = "Щит" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 35, Name = "Копье Сокрушения", Type = "Оружие" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 36, Name = "Посох Мудрости", Type = "Оружие" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 37, Name = "Капюшон Черного Ворона", Type = "Головной убор" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 38, Name = "Кольцо Изумрудного Света", Type = "Украшение" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 39, Name = "Брюки Невидимой Угрозы", Type = "Доспех" });
            uncommonItems.Items.Add(new Uncommon_Item { Id = 40, Name = "Ножны Живого Дерева", Type = "Доспех" });


            Rare_Item rare_Item = new();
            rare_Item.Items.Add(new Uncommon_Item { Id = 41, Name = "Покров выбранного возрождения", Type = "Доспех" });
            rare_Item.Items.Add(new Uncommon_Item { Id = 42, Name = "Железный жезл с сердечником из Скверны", Type = "Оружие" });
            rare_Item.Items.Add(new Uncommon_Item { Id = 43, Name = "Лук священных костей", Type = "Оружие" });
            rare_Item.Items.Add(new Uncommon_Item { Id = 44, Name = "Огнестрел адского цветка", Type = "Оружие" });
            rare_Item.Items.Add(new Uncommon_Item { Id = 45, Name = "Рокочущий большой меч мастера клинка", Type = "Оружие" });
            rare_Item.Items.Add(new Uncommon_Item { Id = 46, Name = "Рубиновый бастион огня Скверны", Type = "Щит" });
            rare_Item.Items.Add(new Uncommon_Item { Id = 47, Name = "Эгида спасения", Type = "Щит" });
            rare_Item.Items.Add(new Uncommon_Item { Id = 48, Name = "Шлем странствующего рыцаря", Type = "Головной Убор" });
            rare_Item.Items.Add(new Uncommon_Item { Id = 49, Name = "Маска злобного фумигатора", Type = "Головной Убор" });
            rare_Item.Items.Add(new Uncommon_Item { Id = 50, Name = "Оскверненная печать верховного друида", Type = "Украшение" });
            

            common_Items.ShowItems();
            uncommonItems.ShowItems();
            rare_Item.ShowItems();
        }
    }
}
