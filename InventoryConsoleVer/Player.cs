using InventoryConsoleVer;

internal class Player
{
    public string Name { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    public List<Inventory_Item> Inventory { get; set; }

    public Player(string name, string playerClass, int level)
    {
        Name = name;
        Class = playerClass;
        Level = level;
        Inventory = new List<Inventory_Item>();
    }

    public void AddItemToInventory(Inventory_Item item)
    {
        Inventory.Add(item);
    }
}
