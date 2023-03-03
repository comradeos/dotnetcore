using System.Text;

Console.OutputEncoding = Encoding.UTF8;

void MyMethod<T>()
{
    if (typeof(T) == typeof(string))
    {
        Console.WriteLine("Это строка, братан!");
    } else {
        Console.WriteLine("Хз шо це, но точно не строка, братан!");
    }
}

MyMethod<string>();
MyMethod<int>();

Delegates.Run();