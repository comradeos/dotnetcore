using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Data.Sqlite;

namespace WebServer;

public class Helper
{
    private static SqliteConnection connection = new("Data Source=database.db");
    private static readonly HttpClient httpClient = new();

    public static Queue<Task> Tasks = new();
    public static List<DbTask> DbTasks = new();

    public static void HandleQueue()
    {
        while (true)
        {
            DbTasks = GetDbTasks();

            foreach (DbTask task in DbTasks)
            {
                string response = SendData(0, task.Address);
                Console.WriteLine($"Processing task #{task.Id}...");
                Thread.Sleep(300);

                if (response != "failed")
                {
                    CompleteDbTask(task.Id);
                    Console.WriteLine($"Task #{task.Id} completed!");
                    Thread.Sleep(300);

                }
                
                // Console.WriteLine(task.Id);
            }

            Thread.Sleep(500);
            Console.WriteLine($"Elements in queue: {DbTasks.Count}");
        }
    }

    public static string SendData(decimal amount, string address)
    {
        string responseString = "failed";

        try
        {
            responseString = httpClient.GetStringAsync(address).Result;
        }
        catch { }

        return responseString;
    }

    public static List<DbTask> GetDbTasks()
    {
        List<DbTask> result = new();

        string query = "SELECT * FROM tasks WHERE status <> 0";

        connection.Open();

        SqliteCommand command;
        SqliteDataReader reader;

        try
        {
            command = new(query, connection);
            reader = command.ExecuteReader();
        } catch {
            Console.WriteLine("Can't get db tasks!");
            return result;
        }

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                DbTask dbTask = new();

                object idObj = reader["id"];
                object deviceObj = reader["device"];
                object addressObj = reader["address"];
                object statusObj = reader["status"];
                object amountObj = reader["amount"];

                try { dbTask.Id = Convert.ToInt32(idObj); } catch { Console.WriteLine("Can't convert id"); }
                try { dbTask.Device = Convert.ToInt32(deviceObj); } catch { Console.WriteLine("Can't convert device"); }
                try { dbTask.Address = Convert.ToString(addressObj) ?? ""; } catch { Console.WriteLine("Can't convert address"); }
                try { dbTask.Status = Convert.ToInt32(statusObj); } catch { Console.WriteLine("Can't convert status"); }
                try { dbTask.Amount = Convert.ToInt32(amountObj); } catch { Console.WriteLine("Can't convert amount"); }

                result.Add(dbTask);
            }
        }

        connection.Close();
        return result;
    }

    public static void CompleteDbTask(int id)
    {
        string query = $"UPDATE tasks SET status = 0 WHERE id = {id};";

        connection.Open();

        SqliteCommand command;

        try
        {
            command = new(query, connection);
            command.ExecuteNonQuery();
        }
        catch
        {
            Console.WriteLine("Can't complete db task!");
        }

        connection.Close();
    }

    public static void AddDbTask(int device, string address, decimal amount)
    {
        string query = $"INSERT INTO tasks (device, address, amount, status) VALUES ({device}, '{address}', {amount}, 1);";

        connection.Open();

        SqliteCommand command;

        try
        {
            command = new(query, connection);
            command.ExecuteNonQuery();
        }
        catch
        {
            Console.WriteLine("Can't complete db task!");
        }

        connection.Close();
    }
}

public class DbTask
{
    public int Id { get; set; }
    public int Device { get; set; }
    public string Address { get; set; } = default!;
    public int Status { get; set; }
    public decimal Amount { get; set; }
}
