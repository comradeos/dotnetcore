namespace Console;

public class Item
{
    public string Name { get; set; }

    public Item (string name)
    {
        Name = name;
    }
}

public class ClassA
{
    public int Id { get; set; }
    public List<int> nums { get; set; } = new();
}

public class Lists
{
    public static void Tests()
    {
        ClassA i1 = new();
        i1.nums = new List<int>() { 1, 2, 3 };

        ClassA i2 = new();
        i1.nums = new List<int>() { 6, 8, 1 };

        List<ClassA> listA = new() { i1, i2 };
        System.Console.WriteLine("Lists->Test()");
    }
}