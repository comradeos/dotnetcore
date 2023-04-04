using MQTTnet;
using System.Text;
using MQTTnet.Client;
using MQTTnet.Packets;
using MQTTnet.Server;
using System.Diagnostics;

// https://github.com/dotnet/MQTTnet
// https://github.com/dotnet/MQTTnet/blob/master/Samples/Client/Client_Subscribe_Samples.cs
// https://github.com/dotnet/MQTTnet/blob/master/Samples/Client/Client_Publish_Samples.cs

class Subscriber
{
    static async Task Main()
    {
        Console.WriteLine("MQTTNet 4.x Subscriber:\nReceived messages:");

        MqttFactory mqttFactory = new();

        IMqttClient client = mqttFactory.CreateMqttClient();

        /*
        var tslOption = new MqttClientOptionsBuilderTlsParameters
        {
            UseTls = true,
            Certificates = new List<X509Certificate>
            {
                new X509Certificate("mosquitto.org.crt")
            },
            AllowUntrustedCertificates = true,
            IgnoreCertificateChainErrors = true,
            IgnoreCertificateRevocationErrors = true
        };
        */

        MqttClientOptions options = new MqttClientOptionsBuilder()
            .WithClientId(Guid.NewGuid().ToString())
            .WithTcpServer("test.mosquitto.org", 1883)
            // .WithTls(tslOption)
            .WithCleanSession()
            .Build();

        await client.ConnectAsync(options);

        var topicFilter = new MqttTopicFilter { Topic = "CelerintTestTopic" };
        
        await client.SubscribeAsync(topicFilter, default);
        
        client.ApplicationMessageReceivedAsync += e =>
        {
            string message = "";
            string topic = "";

            if (e.ApplicationMessage.Payload != null)
            {
                message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                topic = e.ApplicationMessage.Topic;
            }

            Console.WriteLine($"{DateTime.Now} on {topic}: \n{message}");

            SendToDummyApp(message);

            return Task.CompletedTask;
        };

        Console.ReadLine();

        await client.DisconnectAsync();

    }

    private static void SendToDummyApp(string message)
    {
        string fileName = "file.xml";
        File.WriteAllText(fileName, message);

        string fileFullPath = Path.GetFullPath(fileName);

        string dummyAppPath = @"..\..\..\..\DummyApp\bin\Debug\net6.0\DummyApp.exe";

        ProcessStartInfo startInfo = new()
        {
            FileName = dummyAppPath,
            Arguments = fileFullPath
        };

        Process exeProcess = Process.Start(startInfo);

        if (exeProcess != null)
        {
            exeProcess.WaitForExit();
        }
    }
}