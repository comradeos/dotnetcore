namespace ConsoleApp.Modules;

public static class AsyncLocalTest
{
    public static void Test()
    {
        AsyncLocal<int> asyncLocal = new()
        {
            Value = 1
        };
        
        Console.WriteLine($"asyncLocal.Value: {asyncLocal.Value}");
        
        Task task1 = Task.Run(() =>
        {
            asyncLocal.Value = 2;
            Console.WriteLine($"task1: {asyncLocal.Value}");
        });
        
        Task task2 = Task.Run(() =>
        {
            asyncLocal.Value = 3;
            Console.WriteLine($"task2: {asyncLocal.Value}");
        });
        
        Task.WaitAll(task1, task2);
        
        Console.WriteLine($"asyncLocal.Value: {asyncLocal.Value}");
    }
}