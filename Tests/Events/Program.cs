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


class Program
{
    private void PrivateOne(string a, int b)
    {
        Console.WriteLine($"---{a}{b}---");
    }
    public static void Main()
    {
        MyEventClass.Run();
        MyEventClass.MyDelegate = this.PrivateOne;
        MyEventClass.MyDelegate("A",9);
    }
}