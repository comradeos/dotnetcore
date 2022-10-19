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
        Console.WriteLine("> " + (2.31 + float.Parse(strFloatNum)).ToString("0.##")); // формат
        Console.WriteLine("> " + (5.02 + Convert.ToDouble(strFloatNum2)));
        
        Console.WriteLine("PI: " + Math.PI);
        Console.WriteLine("ABS: " + Math.Abs(-231)); // число по модую
        Console.WriteLine("Ceiling: " + Math.Ceiling(4.11)); // 5 округляет к большему
        Console.WriteLine("Floor: " + Math.Floor(4.11)); // 4 оругляет к большему
        Console.WriteLine("Round: " + Math.Round(4.56)); // 5 оругляет
        Console.WriteLine("Round: " + Math.Round(4.36)); // 4 оругляет
        
        Console.WriteLine("Min: " + Math.Min(1,2)); // 1
        Console.WriteLine("Max: " + Math.Max(1,2)); // 2
        Console.WriteLine("Pow: " + Math.Pow(5,3)); // 125 степень
        Console.WriteLine();
        Console.WriteLine();

        return;
        Console.WriteLine("Введите радиус круга: ");
        var radius = Convert.ToDouble(Console.ReadLine());
        var area = Math.PI * Math.Pow(radius, 2);
        Console.WriteLine("Площадь круга с радиусом {0} равна {1}", radius, area);

    }
}