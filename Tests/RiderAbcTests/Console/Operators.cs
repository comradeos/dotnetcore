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
        if (myObj is MyClass aaa)
        {
            System.Console.WriteLine(aaa.Name);
        }
        System.Console.WriteLine("----------");
        
    }
}