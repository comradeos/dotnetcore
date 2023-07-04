using Microsoft.Data.Sqlite;
using WebServer.Models;

namespace WebServer;

public class DataBase
{
    private static readonly SqliteConnection connection = new("Data Source=database.db");
    private static readonly string SenderTaskTable = "sender_tasks";

    public static long? Add(string device, string address, decimal amount)
    {
        long? index = null;

        string query = $"INSERT INTO {SenderTaskTable} (device, address, amount, status) " +
            $"VALUES ('{device}', '{address}', {amount}, {(int)Status.FAILURE});" +
            $"SELECT last_insert_rowid();";

        try
        {
            connection.Open();
            SqliteCommand command = new(query, connection);
            object? indexObj = command.ExecuteScalar();
            index = (indexObj != null) ? (long)indexObj : index;
            connection.Close();
        }
        catch
        {
            Console.WriteLine($"Can't add db sender task: Send {amount} UAH to {device} ({address})!");
        }
        
        return index;
    }

    public static void Complete(long id)
    {
        string query = $"UPDATE {SenderTaskTable} SET status = {(int)Status.SUCCESS} WHERE id = {id};";

        try
        {
            connection.Open();
            SqliteCommand command = new(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        catch
        {
            Console.WriteLine($"Can't complete db sender task id: {id}!");
        }
    }
}

