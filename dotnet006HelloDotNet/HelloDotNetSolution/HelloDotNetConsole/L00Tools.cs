namespace HelloDotNetConsole;

public static class L00Tools {
    public static void Line() {
        Console.WriteLine("--------------------------------");
    }

    public static void dd(object value) {
        Console.WriteLine();
        Line();
        Console.WriteLine(value.GetType());
        Console.WriteLine(value);
        Line();
        Console.WriteLine();
        System.Environment.Exit(0);
    }
}