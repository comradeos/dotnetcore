using ConsoleApp.Modules;

namespace ConsoleApp.Tests;

public static class Attributes
{
    public static void Test()
    {
        Console.WriteLine("Attributes.Test");

        User user = new(){Name = "John Doe"};

        Type userType = user.GetType();

        object[] attributes = userType.GetCustomAttributes(false);

        foreach (object item in attributes)
        {
            if (item is not Io io)
            {
                continue;
            }

            Console.WriteLine($"Attribute Description: {io.Description}");
            Console.WriteLine($"Attribute Number: {io.Number}");
        }
    }
}

[Io(Number = 25, Description = "Hello")]
internal class User
{
    public required string Name { get; set; }
}

[AttributeUsage(AttributeTargets.Class)]
internal class Io() : Attribute
{
    public int Number { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
}