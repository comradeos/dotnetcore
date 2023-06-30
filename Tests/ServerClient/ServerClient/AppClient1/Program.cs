using System.Net;
using System.Text;

string appName = "AppClient1";

string startMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Application '{appName}' started!";
Console.WriteLine(startMessage);

HttpListener listener = new();

listener.Prefixes.Add("http://127.0.0.1:8881/");
listener.Start();

while (true)
{
    HttpListenerContext context = await listener.GetContextAsync();

    string? amount = context.Request.QueryString["amount"];

    byte[] outputBytes = Encoding.UTF8.GetBytes("Ok");

    if (amount != null)
    {
        outputBytes = Encoding.UTF8.GetBytes($"Received {amount} UAH!");
    }

    string outputString = Encoding.UTF8.GetString(outputBytes);

    context.Response.StatusCode = 200;
    context.Response.KeepAlive = false;
    context.Response.ContentLength64 = outputBytes.Length;

    Stream output = context.Response.OutputStream;

    output.Write(outputBytes, 0, outputBytes.Length);
    context.Response.Close();

    string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    if (amount != null)
    {
        Console.WriteLine($"[{time}] {outputString}");
    }
}