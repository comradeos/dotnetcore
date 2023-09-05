namespace ConsoleApp.Modules;


public class MyClass
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public MyClass(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class TryGetByValuesProperty
{
    public static void Test()
    {
        Dictionary<int, MyClass> dict = new();
        
        MyClass mc1 = new MyClass(1, "a");
        MyClass mc2 = new MyClass(1, "b");
    
        dict.Add(1, mc1);
        dict.Add(2, mc2);

        MyClass res = dict.Where(i => i.Value.Name == "a")
            .Select(i=>i.Value).ToList()[0];

        Console.WriteLine(dict.Count);
    }
}