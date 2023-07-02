namespace TempApi;

public class Helper
{
    public static Queue<Task> tasks = new();
    public static Queue<string> strings = new();

    public static void SomeAction(int taskId)
    {
        for (int i = 0; i < 10; i++) 
        {
            // Console.WriteLine($"Doing something... (Task id {taskId})");
            Thread.Sleep(1000);
        }
    }

    public static void TasksCounter()
    {
        while (true)
        {
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Tasks: {strings.Count}");
            Console.ForegroundColor = ConsoleColor.Gray;

            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }
        }
    }

    /*
    public static void RemoveTask()
    {
        while (true)
        {
            foreach (var item in tasks)
            {
                if (item.IsCompleted)
                {
                    tasks.Dequeue();
                }
            }
        }
    }
    */

}
