using System.Net;
using System.Text;

HttpListener listener = new();

listener.Prefixes.Add("http://127.0.0.1:8888/");

listener.Start();

while (true)
{
    HttpListenerContext context = await listener.GetContextAsync();
    
    // HttpListenerRequest request = context.Request;

    // Console.WriteLine(context.Request.HttpMethod);
    // Console.WriteLine(request.RawUrl);
        
    string inputBody = new StreamReader(context.Request.InputStream).ReadToEnd();

    byte[] outputBytes = Encoding.UTF8.GetBytes("Data received!");
    string outputString = Encoding.UTF8.GetString(outputBytes);

    context.Response.StatusCode = 200;
    context.Response.KeepAlive = false;
    context.Response.ContentLength64 = outputBytes.Length;

    Stream output = context.Response.OutputStream;

    output.Write(outputBytes, 0, outputBytes.Length);
    context.Response.Close();

    string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    // Console.WriteLine(inputBody);
    Console.WriteLine($"[{time}] {outputString}");
}

// server.Stop();