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
        
        foreach (var t in words)
        {
            Console.WriteLine(t);
        }
        
        
        Console.WriteLine("------------------------------------");
        
        // установка случайных чисел и их сумма
        
        var randNums = new short[10]; // новый массив типа int16
        var random = new Random();  // объект генератора  
        var sum = 0;
        
        for (var i = 0; i < randNums.Length; i++)
        {
            var t = random.Next(-15, 15);
            randNums[i] = Convert.ToInt16(t);
            sum += randNums[i];
            Console.WriteLine(randNums[i] + " (sum = " + sum + ")");
        }
        
        Console.WriteLine("------------------------------------");

        foreach (var item in randNums)
        {
            Console.WriteLine(item);
        }

    }
}