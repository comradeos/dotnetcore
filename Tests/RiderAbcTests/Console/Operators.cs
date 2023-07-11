namespace Console;

public class MyClass
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public static class Operators
{
    public static void Tests()
    {
        MyClass myObj = new()
        {
            Id = 1,
            Name = "MyName"
        };
        
        System.Console.WriteLine("----------");
        if (myObj is MyClass inst)
        {
            System.Console.WriteLine(inst.Name);
        }
        System.Console.WriteLine("----------");
        // 1 2 3 4 5 6 7 8 9 10 11 12 13 14 
    }
}