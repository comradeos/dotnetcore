namespace ConsoleApp.Modules;

public class SplitList
{
    public static void Test()
    {
        List<int> nums = [0, 1, 2, 3, 4, 5, 6];
        
        List<int> p1 = nums.GetRange(0, 5);
        List<int> p2 = nums.GetRange(5, 2);
        
        Console.WriteLine(string.Join(", ", p1));
        Console.WriteLine(string.Join(", ", p2));
        
    }
}