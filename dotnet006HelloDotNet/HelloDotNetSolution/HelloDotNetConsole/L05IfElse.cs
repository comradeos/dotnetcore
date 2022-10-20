namespace HelloDotNetConsole;

public static class L05IfElse
{
    public static void Run()
    {
        var word = "abc";

        if (word.Length > 2)
        {
            Console.WriteLine("cool: ");
            Console.WriteLine("word.Length > 2");
        }
        else
        {
            Console.WriteLine("cool: ");
            Console.WriteLine("word.Length <2");
        }

        const bool isHappy = true;
        const string result = isHappy ? "You are happy!" : "You are not happy...";
        Console.WriteLine(result);

        const int num = 3;

        if (num > 5)
            Console.WriteLine(" > 5 ...");
        if (num > 1) Console.WriteLine(" > 1 ...");

        const int num2 = 123;
        if (num2 > 10 && num2 > 120) Console.WriteLine(">>> " + num2); // >>> 123

        const int num3 = 1;
        const int num4 = 50;

        if (num3 > 10 || num4 > 10) Console.WriteLine(">>> " + num3 + " ... " + num4); // >>> 1 ... 50
    }
}