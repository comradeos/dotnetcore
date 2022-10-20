namespace HelloDotNetConsole;

public static class L08Arrays
{
    public static void Run()
    {
        byte[] nums = new byte[5]; // var nums = new byte[5];
        nums[0] = 10;
        nums[1] = 25;
        nums[2] = 30;
        nums[3] = 41;
        nums[4] = 54;

        Console.WriteLine(nums); // System.Byte[]
        for (var i = 0; i < nums.Length; i++)
        {
            Console.WriteLine(nums[i]);
        }

        string[] words = new string[]
        {
            "Ann",
            "Bob",
            "Alex",
        }; // var words = new string[] { "John", "Bob", "Alex", };

        words[1] = "Walley";
        
        for (var i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }
        
    }
}