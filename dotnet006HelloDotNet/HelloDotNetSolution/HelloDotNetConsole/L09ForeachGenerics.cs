namespace HelloDotNetConsole;

public static class L09ForeachGenerics
{
    public static void Run()
    {
        short[] nums = {
            10, 15, 81, 94, 10, 
        }; // массив

        foreach (var num in nums)
        {
            Console.WriteLine(num);
        }
    }
}