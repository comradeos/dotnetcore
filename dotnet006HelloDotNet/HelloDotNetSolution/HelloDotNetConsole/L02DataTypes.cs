namespace HelloDotNetConsole;

public static class L02DataTypes
{
    public static void Run()
    {
        var fnum = 3212.2142f;
        var dnum = 33231.3412;
        Console.WriteLine("переменная fnum: " + fnum);
        Console.WriteLine("переменная dnum: " + dnum);

        var word = "Переменная";
        Console.WriteLine(word + ": " + dnum);

        var symbol = 'A';
        Console.WriteLine("Символ: " + symbol);

        var isHappy = true;
        Console.WriteLine("isHappy: " + isHappy);
    }
}