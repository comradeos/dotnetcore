using HelloDotNetConsole;

class Main1
{
    public static void Main2()
    {
        

        // byte number = 10;
        // short number = 10;
        // long number = 10;
        var n = new int();
        n = 231231;
        Console.WriteLine(n);
        
        int num1 = -231; // и положительные и отрицательные
        uint num2 = 231; // только положительные
        byte num3 = 255; // только в диапазоне 0-255

        Console.WriteLine("переменная num1: " + num1 + ".");
        Console.WriteLine("переменная num2: " + num2 + ".");
        Console.WriteLine("переменная num1: " + num3 + ".");
        Console.WriteLine("переменная num1: " + num3 + ".");

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


        int num4 = 0, num5 = 0;
        num4 = Convert.ToInt32(Console.ReadLine());
        num5 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("num4: " + num4 + "\nnum_2: " + num5);
        
        // Console.ReadKey(); // считать один символ
        Lesson04.run();
    } 
}

