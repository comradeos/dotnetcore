using System.Collections.Concurrent;

namespace WebServer;

public class QueueManager
{
    private ConcurrentDictionary<string,Task> tasks = new();

    public void AddTask(string id, Task task)
    {
        tasks.TryAdd(id, task);
    }

    public void ProcessTasks()
    {
        while (true)
        {
            foreach (KeyValuePair <string,Task> item in tasks)
            {
                string id = item.Key;
                Task task = item.Value;

                if (task.IsCompleted)
                {
                    tasks.TryRemove(id, out _);
                }
            }

            Console.WriteLine($"Tasks: {tasks.Count}");
            Thread.Sleep(1000);
        }
    }
}

