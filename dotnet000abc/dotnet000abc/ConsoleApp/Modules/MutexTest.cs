namespace ConsoleApp.Modules;

public static class MutexTest
{
    public static void Test()
    {
        int number = 0;
        Mutex mutex = new();
        
        Task task1 = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                mutex.WaitOne();
                ++number;
                Console.WriteLine($"task1: {number}");
                mutex.ReleaseMutex();
            }
        });
        
                
        Task task2 = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                mutex.WaitOne();
                ++number;
                Console.WriteLine($"task2: {number}");
                mutex.ReleaseMutex();
            }
        });
        
        Task.WaitAll(task1, task2);
        
    }
}