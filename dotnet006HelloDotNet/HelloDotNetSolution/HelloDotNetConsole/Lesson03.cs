namespace HelloDotNetConsole;

public class Lesson03
{
    public static void Run()
    {
        int num4 = 0, num5 = 0;
        num4 = Convert.ToInt32(Console.ReadLine());
        num5 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("num4: " + num4 + "\nnum_2: " + num5);
        // Console.ReadKey(); // считать один символ
    }
}