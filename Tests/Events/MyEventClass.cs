class MyEventClass
{
    public delegate void MyDelegate(string a, int b); // делегат
    public static event MyDelegate? MyEvent; // событие

    public static void MyMethod(string myString, int myInt)
    {
        Console.WriteLine($">>> {myString} >>> {myInt}");
    }

    public static void Run()
    {
        MyEvent += MyMethod;
        MyEvent("A", 7);
    }

}
