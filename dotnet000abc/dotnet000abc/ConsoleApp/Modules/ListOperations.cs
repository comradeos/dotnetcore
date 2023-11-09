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

internal class Product
{
    public string Name { get; set; }
    public Product(string name)
    {
        Name = name;
    }
}

public static class ListOperations
{
    public static void Test()
    {
        /*
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
        */

        List<Product> products = new()
        {
            new Product("123"),
            new Product("321"),
            new Product("123-432"),
            new Product("2C"),
        };
        
        List<Product> sortedProducts = products.OrderBy(i=>i.Name).ToList();

        foreach (Product product in sortedProducts)
        {
            Console.WriteLine(product.Name);
        }
    }
}