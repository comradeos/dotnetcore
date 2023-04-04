using MQTTnet;
using System.Text;
using MQTTnet.Client;
using MQTTnet.Packets;
using MQTTnet.Server;

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

        MqttClientOptions options = new MqttClientOptionsBuilder()
            .WithClientId(Guid.NewGuid().ToString())
            .WithTcpServer("test.mosquitto.org", 1883)
            .WithCleanSession()
            .Build();

        await client.ConnectAsync(options);

        var topicFilter = new MqttTopicFilter { Topic = "CelerintTestTopic" };
        
        await client.SubscribeAsync(topicFilter, default);
        
        client.ApplicationMessageReceivedAsync += e =>
        {
            string message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            Console.WriteLine($"{DateTime.Now}: {message}");
            return Task.CompletedTask;
        };

        Console.ReadLine();

        await client.DisconnectAsync();

    }
}