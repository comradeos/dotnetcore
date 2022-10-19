namespace HelloDotNetConsole;

public static class Lesson06
{
    public static void Run()
    {
        const int num = 231;
        
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