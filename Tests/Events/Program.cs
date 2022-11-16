class MyEventClass
{
    public delegate void MyDelegate(string a, int b); // делегат
    public event MyDelegate? MyEvent; // событие
    public void MyMethod(string myString, int myInt) // метод
    {
        Console.WriteLine($">>> {myString} >>> {myInt}");
    }

    public void Run()
    {
        this.MyEvent += MyMethod;
        this.MyEvent("A", 7);
    }
}


class Program
{
    public static void Main()
    {
        MyEventClass c1 = new();
        c1.Run();
    }
}