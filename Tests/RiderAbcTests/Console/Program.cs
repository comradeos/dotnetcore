class Item
{
    public string Name { get; set; }

    public Item (string name)
    {
        Name = name;
    }
}


class Program
{
    public static void Main()
    {
        List<Item> items = new(2);
        
        items[0] = new Item("a");
        
        Console.WriteLine(items[0].Name );
    }
}
