using Microsoft.Data.Sqlite;

namespace WebServer;

public class Helper
{
    private static readonly SqliteConnection connection = new("Data Source=database.db");
    private static readonly string SenderTaskTable = "sender_tasks";
    private static readonly string SenderLogTable = "sender_log";

    private static readonly HttpClient httpClient = new();

    public static List<SenderTask> DbSenderTasks = new();

    public static void ProcessDbSenderTasks()
    {
        while (true)
        {
            DbSenderTasks = GetDbSenderTasks();

            Console.Write($"Database sender tasks in queue: {DbSenderTasks.Count}\r");

            foreach (SenderTask task in DbSenderTasks)
            {
                Console.WriteLine($"\nProcessing task #{task.Id}...");
                string response = SendData(task.Amount, task.Address);
                Thread.Sleep(300);

                if (response != "failed")
                {
                    CompleteDbSenderTask(task.Id);
                    Console.WriteLine($"Task #{task.Id} completed!");
                    Thread.Sleep(300);
                }
            }
            Thread.Sleep(500);
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

    public static List<SenderTask> GetDbSenderTasks()
    {
        List<SenderTask> result = new();

        string query = $"SELECT * FROM {SenderTaskTable} WHERE status <> 0";

        connection.Open();

        SqliteCommand command;
        SqliteDataReader reader;

        try
        {
            command = new(query, connection);
            reader = command.ExecuteReader();
        } catch {
            Console.WriteLine("Can't get DB sender tasks!");
            return result;
        }

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                SenderTask senderTask = new();

                object idObj = reader["id"];
                object deviceObj = reader["device"];
                object addressObj = reader["address"];
                object statusObj = reader["status"];
                object amountObj = reader["amount"];

                try { senderTask.Id = Convert.ToInt32(idObj); } catch { Console.WriteLine("Can't convert 'id' value to Int32!"); }
                try { senderTask.Status = Convert.ToInt32(statusObj); } catch { Console.WriteLine("Can't convert 'status' value to Int32!"); }
                try { senderTask.Amount = Convert.ToInt32(amountObj); } catch { Console.WriteLine("Can't convert 'amount' value to Int32!"); }

                senderTask.Device = (string)deviceObj;
                senderTask.Address = (string)addressObj;

                result.Add(senderTask);
            }
        }

        connection.Close();

        return result;
    }

    public static void CompleteDbSenderTask(int id)
    {
        string query = $"UPDATE {SenderTaskTable} SET status = 0 WHERE id = {id};";

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

    public static void AddDbSenderTask(string device, string address, decimal amount)
    {
        string query = $"INSERT INTO {SenderTaskTable} (device, address, amount, status) VALUES ('{device}', '{address}', {amount}, 1);";

        connection.Open();

        SqliteCommand command;

        try
        {
            command = new(query, connection);
            command.ExecuteNonQuery();
        }
        catch
        {
            Console.WriteLine("Can't add db task!");
        }

        connection.Close();
    }
}

public class SenderTask
{
    public int Id { get; set; }
    public string Device { get; set; } = default!;
    public string Address { get; set; } = default!;
    public decimal Amount { get; set; }
    public int Status { get; set; }
}
