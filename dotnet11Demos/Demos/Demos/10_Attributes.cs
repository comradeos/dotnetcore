namespace Demos;

internal class ClassAttributes
{
    public static void Demo()
    {
        MyClass myClass = new MyClass();
    }
}

class MyCustomNoValueAttribute : Attribute
{
}

class MyCustomValueAttribute : Attribute
{
    public string Value { get; }
    
    public MyCustomValueAttribute(string value)
    {
        Value = value;
    }
}

// [MyCustomNoValue]
[MyCustomValue("Hello, World!")]
class MyClass
{
    public MyClass()
    {
        PrintAttributes();
    }

    private void PrintAttributes()
    {
        if (Attribute.IsDefined(this.GetType(), typeof(MyCustomNoValueAttribute)))
        {
            Console.WriteLine("MyCustomNoValueAttribute is defined on MyClass");
        }
        
        MyCustomValueAttribute? valueAttribute = (MyCustomValueAttribute?)Attribute.GetCustomAttribute(this.GetType(), typeof(MyCustomValueAttribute));
        
        if (valueAttribute != null)
        {
            Console.WriteLine($"MyCustomValueAttribute is defined on MyClass with value: {valueAttribute.Value}");
        }
    }
}