namespace HelloDotNetConsole;

public static class L07ForWhileDo {
    
    public static void Run() {
        for (var i = 0; i <= 10; i++) Console.Write(i + ", ");

        Console.WriteLine();

        var num = 10;
        while (num > 0) {
            Console.Write(num + ", ");
            num--;
        }

        Console.WriteLine();

        var num2 = 0;
        do {
            Console.Write(num2 + ", ");
            num2++;
        } while (num2 <= 10);
    }
    
}