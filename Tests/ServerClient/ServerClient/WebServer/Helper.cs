using Microsoft.Data.Sqlite;

namespace WebServer;

enum Status
{
    SUCCESS,
    FAILURE
}

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

            string counterMessage = $"Database sender tasks in queue: {DbSenderTasks.Count}";

            if (DbSenderTasks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{counterMessage}\r");
                Console.ForegroundColor = ConsoleColor.Gray;
            } else
            {
                AlertMessage(counterMessage);
            }

            foreach (SenderTask task in DbSenderTasks)
            {
                Console.WriteLine($"Processing task id {task.Id}...");
                string response = SendData(task.Amount, task.Address);
                Thread.Sleep(300);

                if (response != "failed")
                {
                    CompleteDbSenderTask(task.Id);
                    SuccessMessage($"Task id {task.Id} completed!");
                } else
                {
                    FailureMessage($"Task id {task.Id} failed to complete!");
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
            responseString = httpClient.GetStringAsync($"{address}/?amount={amount}").Result;
        }
        catch { }

        return responseString;
    }

    public static List<SenderTask> GetDbSenderTasks()
    {
        List<SenderTask> result = new();

        string query = $"SELECT * FROM {SenderTaskTable} WHERE status <> {(int)Status.SUCCESS}";

        connection.Open();

        SqliteCommand command;
        SqliteDataReader reader;

        try
        {
            command = new(query, connection);
            reader = command.ExecuteReader();
        } catch {
            Console.WriteLine("Can't get db sender tasks!");
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
                try { senderTask.Amount = Convert.ToDecimal(amountObj); } catch { Console.WriteLine("Can't convert 'amount' value to ToDecimal!"); }

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
        string query = $"UPDATE {SenderTaskTable} SET status = {(int)Status.SUCCESS} WHERE id = {id};";

        connection.Open();

        SqliteCommand command;

        try
        {
            command = new(query, connection);
            command.ExecuteNonQuery();
        }
        catch
        {
            Console.WriteLine("Can't complete db sender task!");
        }

        connection.Close();
    }

    public static void AddDbSenderTask(string device, string address, decimal amount)
    {
        string query = $"INSERT INTO {SenderTaskTable} (device, address, amount, status) VALUES ('{device}', '{address}', {amount}, {(int)Status.FAILURE});";

        connection.Open();

        SqliteCommand command;

        try
        {
            command = new(query, connection);
            command.ExecuteNonQuery();
        }
        catch
        {
            Console.WriteLine("Can't add db sender task!");
        }

        connection.Close();
    }

    public static void SuccessMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void FailureMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void AlertMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Gray;
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
