using System.Net;
using System.Text;

HttpListener listener = new();

// установка адресов прослушки
listener.Prefixes.Add("http://127.0.0.1:8888/");

listener.Start(); // начинаем прослушивать входящие подключения

while (true)
{
    // получаем контекст
    HttpListenerContext context = await listener.GetContextAsync();
    HttpListenerRequest request = context.Request;

    Console.WriteLine(context.Request.HttpMethod);
    Console.WriteLine(request.RawUrl);

    foreach (string item in request.Headers.Keys)
    {
        // Console.WriteLine($"{item}:{request.Headers[item]}");
    }

    // Get the data from the HTTP stream
    string body = new StreamReader(context.Request.InputStream).ReadToEnd();

    byte[] bytes = Encoding.UTF8.GetBytes("Data received!");

    context.Response.StatusCode = 200;
    context.Response.KeepAlive = false;
    context.Response.ContentLength64 = bytes.Length;

    Stream output = context.Response.OutputStream;
    output.Write(bytes, 0, bytes.Length);
    context.Response.Close();

    Console.WriteLine(body);

    /*
    var response = context.Response;

    // отправляемый в ответ код htmlвозвращает
    string responseText = @"ok";

    byte[] buffer = Encoding.UTF8.GetBytes(responseText);

    // получаем поток ответа и пишем в него ответ
    response.ContentLength64 = buffer.Length;
    using Stream output = response.OutputStream;

    // отправляем данные
    await output.WriteAsync(buffer);
    await output.FlushAsync();

    Console.WriteLine("done");
    */
}

// server.Stop();