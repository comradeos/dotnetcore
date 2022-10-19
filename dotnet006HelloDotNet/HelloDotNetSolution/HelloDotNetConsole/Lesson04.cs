namespace HelloDotNetConsole;

public static class Lesson04
{
    public static void Run()
    {
        // Console.Write("Input doubleUserInput: ");
        // var doubleUserInput = Convert.ToDouble(Console.ReadLine());
        
        // Console.Write("Input floatUserInput: ");
        // var floatUserInput = float.Parse(Console.ReadLine() ?? string.Empty);

        // Console.WriteLine("doubleUserInput: " + doubleUserInput + ", floatUserInput: " + floatUserInput);

        const float a = 21.23f;
        const float b = 61.01f;
        
        Console.WriteLine("a = " + a + "b = " + b);
        Console.WriteLine("a + b = " + (a + b));
        Console.WriteLine("a - b = " + (a - b));
        Console.WriteLine("a * b = " + (a * b));
        Console.WriteLine("a / b = " + (a / b));
        Console.WriteLine("a % b = " + (a % b));

        var num = 7.231f + 1f;
        num = 2.5f;
        
        var str = "hello";
        str = "world!";
            
        Console.WriteLine(num);
        Console.WriteLine(str);

        var strFloatNum = "2.11";
        var strFloatNum2 = "3.22";
        Console.WriteLine(">" + (2.31 + float.Parse(strFloatNum)).ToString("0.##"));
        Console.WriteLine(">" + (5.02 + Convert.ToDouble(strFloatNum2)));

    }
}