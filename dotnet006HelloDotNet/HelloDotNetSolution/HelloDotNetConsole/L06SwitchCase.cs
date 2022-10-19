namespace HelloDotNetConsole;

public static class L06SwitchCase
{
    public static void Run()
    {
        Console.Write("Input num: ");
        var num = Convert.ToInt32(Console.ReadLine());
        
        switch (num)
        {
            case 1:
                Console.WriteLine(111);
                break;
            case 2:
                Console.WriteLine(222);
                break;
            
            case 3:
                Console.WriteLine(333);
                break;
            default:
                Console.WriteLine("default");
                break;
        }
    }
}