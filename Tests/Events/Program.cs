class MyEventClass
{
    public delegate void MyDelegate(string a, int b); // делегат
    public static event MyDelegate? MyEvent; // событие

    public static void MyMethod(string myString, int myInt)
    {
        Console.WriteLine($">>> {myString} >>> {myInt}");
    }

    public void Run()
    {
        MyEvent += MyMethod;
        MyEvent("A", 7);
        
    }
}
class MyDelegateClass
{
    public delegate void MyDelegate(string a, int b);
    public static void MyMethod(string myString, int myInt)
    {
        Console.WriteLine($">>> {myString} >>> {myInt}");
    }

    public void Run()
    {
        MyDelegate d = MyMethod;
        d("B", 8);
        
    }
}


class Program
{
    public static void Main()
    {
        MyEventClass c1 = new();
        c1.Run();

        MyDelegateClass d1 = new();
    }
}