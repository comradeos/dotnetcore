namespace HelloDotNetConsole;

public static class Lesson02
{
    public static void Run()
    {
        float fnum = 3212.2142f;
        double dnum = 33231.3412;
        Console.WriteLine("переменная fnum: " + fnum);
        Console.WriteLine("переменная dnum: " + dnum);

        string word = "Переменная";
        Console.WriteLine(word + ": " + dnum);
        
        char symbol = 'A';
        Console.WriteLine("Символ: " + symbol);
        
        bool isHappy = true;
        Console.WriteLine("isHappy: " + isHappy);
    }
}