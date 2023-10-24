namespace ConsoleApp.Modules;

public static class IndexOfSeveralProperties
{
    public static void Test()
    {
        List<Item> list = new()
        {
            new Item(1, "a"),
            new Item(2, "b"),
        };

        int itemIndex = list.FindIndex(i => i is { Id: 2, Name: "b" });
        Console.WriteLine(itemIndex);
        
        Console.WriteLine((decimal)121*5/100);

    }
    
    private class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Item(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

