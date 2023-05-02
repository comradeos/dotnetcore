namespace Console;

public class Item
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
            items.Add(new Item("ItemA"));
        }
        
        System.Console.WriteLine(items[0].Name );

    }
}