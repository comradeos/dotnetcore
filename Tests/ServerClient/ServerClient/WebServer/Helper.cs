namespace WebServer;

public class Helper
{
    public static readonly QueueManager queueManager = new();

    public static void Send(string device, decimal amount, string address)
    {
        long? rowId = DataBase.Add(device, address, amount);

        HttpClient httpClient = new();

        string? responseString = null;

        while (responseString == null)
        {
            try
            {
                responseString = httpClient.GetStringAsync($"{address}/?amount={amount}").Result;
            }
            catch { }

            Thread.Sleep(500);
        }

        if (rowId != null)
        {
            DataBase.Complete((long)rowId);
        }
    }
}
