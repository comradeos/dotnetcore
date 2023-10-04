namespace ConsoleApp.Modules;


class MyItem
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public MyItem(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public static class ListOperations
{
    public static void Test()
    {
        List<MyItem> items = new()
        {
            new MyItem(1, "A"),
            new MyItem(2, "B"),
            new MyItem(3, "C"),
        };

        items.RemoveAll(i => i.Id == 3);
        
        foreach (MyItem item in items) {
            Console.WriteLine($"item.Id {item.Id} item.Name {item.Name}");
        }
    }
}