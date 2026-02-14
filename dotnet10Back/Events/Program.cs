class Program {
    public static event Func<int, int> MyEvent;

    private static void Main() {
        Console.WriteLine("UNDERSTANGING EVENTS:");

        // MyEvent += MyAction1;
        // MyEvent += MyAction2;
        MyEvent += MyAction3;
        MyEvent.Invoke(1);
    }

    private static void MyAction1() {
        Console.WriteLine("MyAction... 1");
    }

    private static void MyAction2() {
        Console.WriteLine("MyAction... 2");
    }

    private static int MyAction3(int a) {
        Console.WriteLine("MyAction... 3");
        return 1;
    }
}