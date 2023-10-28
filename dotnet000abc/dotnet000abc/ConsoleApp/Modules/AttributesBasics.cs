namespace ConsoleApp.Modules;

public static class AttributesBasics
{
    public static void Test()
    {
        User user = new() { Age = 20, Name = "John Doe" };
        CheckAttributes(user);
    }

    private static void CheckAttributes(User user)
    {
        Type type = typeof(User);
        object[] attributes = type.GetCustomAttributes(false);
        
        foreach (Attribute attribute in attributes)
        {
            if (attribute is MyAttributeAttribute a)
            {
                Console.WriteLine(a.Age);
            }
        }
    }
}

public class MyAttributeAttribute : Attribute
{
    public int Age { get; }
    public MyAttributeAttribute() {}
    public MyAttributeAttribute(int age) { Age = age; }
}

[MyAttribute(18)]
public class User
{
    public int Age { get; set; }
    public string Name { get; set; } = default!;
}