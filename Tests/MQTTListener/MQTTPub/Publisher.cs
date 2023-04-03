using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

class Publisher
{
    static async Task Main()
    {
        Console.WriteLine("[ MQTT Publisher v1 ]");

        MqttFactory mqttFactory = new();

        IMqttClient client = mqttFactory.CreateMqttClient();

        IMqttClientOptions options = new MqttClientOptionsBuilder()
            .WithClientId(Guid.NewGuid().ToString())
            .WithTcpServer("test.mosquitto.org", 1883)
            .WithCleanSession()
            .Build();

        await client.ConnectAsync(options);

        Console.WriteLine("Input messages:");

        while (true)
        {
            string? line = Console.ReadLine();

            await PublishMessageAsync(client, line);
        }

        // await client.DisconnectAsync();
    }

    private static async Task PublishMessageAsync(IMqttClient client, string? messagePayload)
    {
        MqttApplicationMessage message = new MqttApplicationMessageBuilder()
            .WithTopic("IaroslavOs")
            .WithPayload(messagePayload)
            .Build();

        if (client.IsConnected)
        {
            await client.PublishAsync(message);
        }
    }

}