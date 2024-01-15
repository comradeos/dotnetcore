namespace ConsoleApp.Modules;

public static class RaceCondition
{
    public static void Test()
    {
        int number = 0;

        Task task1 = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                ++number;
                Console.WriteLine($"task1: {number}");
            }
        });
        
        Task task2 = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                --number;
                Console.WriteLine($"task2: {number}");
            }
        });
    
        Task.WaitAll(task1, task2);
        Console.WriteLine($"number: {number}");
    }
}