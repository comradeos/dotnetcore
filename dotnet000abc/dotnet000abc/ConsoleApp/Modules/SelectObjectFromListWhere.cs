namespace ConsoleApp.Modules;



internal class ItemObject
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}

public class SelectObjectFromListWhere
{
    public static void Test()
    {
        List<ItemObject> items = new();

        ItemObject item1 = new() { Id = 1, Name = "N1" };
        ItemObject item2 = new() { Id = 2, Name = "N2" };
        ItemObject item3 = new() { Id = 3, Name = "N3" };
        
        items.Add(item1);
        items.Add(item2);
        items.Add(item3);

        int counter = items.Where(i => i is { Id: 1, Name: "N2" }).ToList().Count;
        Console.WriteLine(counter);
    }
}