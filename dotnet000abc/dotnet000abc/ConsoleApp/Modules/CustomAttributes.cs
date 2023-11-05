using System.Reflection;

namespace ConsoleApp.Modules;

public static class CustomAttributes
{
    public static void Test()
    {
        Human human = new("Iaroslav", 33);

        PropertyInfo[] properties = typeof(Human).GetProperties();
        
        foreach (PropertyInfo property in properties)
        {
            object[] attributes = property.GetCustomAttributes(true);
            foreach (Attribute attribute in attributes)
            {
                if (attribute is CustomAttribute customAttribute)
                {
                    Console.WriteLine($"Hey this one has a custom attribute ----> {customAttribute.Value}");
                }
            }
        }

    }
}

internal class CustomAttribute : Attribute
{
    public string Value;

    public CustomAttribute(string value="default attribute value")
    {
        Value = value;
    }
}

internal class Human
{
    [CustomAttribute]
    public string Name { get; set; }
    public int Age { get; set; }

    public Human(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

