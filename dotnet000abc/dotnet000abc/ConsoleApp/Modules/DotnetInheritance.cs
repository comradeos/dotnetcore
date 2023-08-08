using System.IO.Compression;

namespace ConsoleApp.Modules;

public class Person
{
    public string Name { get; set; } = default!;
    public int Age { get; set; }
}

public class Employee : Person
{
    public int Salary { get; set; }
}

public static class DotnetInheritance
{
    public static void Test()
    {
        Employee employee = new()
        {
            Name = "Name1",
            Age = 24,
            Salary = 2500
        };

        Console.WriteLine(employee.Name);
        Console.WriteLine(employee.Age);
        Console.WriteLine(employee.Salary);
    }
}