class Item
{
    public string Name { get; set; }

    public Item (string name)
    {
        Name = name;
    }
}


internal static class Program
{
    public static void Main()
    {
        List<Item> items = new();

        if (items.ElementAtOrDefault(0) == null)
        {
            items.Add(new Item("A"));
        }
        
        Console.WriteLine(items[0].Name );
        
        Environment.Exit(0);        
        if (items.ElementAtOrDefault(0) == null)
        {
            items[0] = new Item("a");
        }
        
        Console.WriteLine(items[0].Name );
    }
}
