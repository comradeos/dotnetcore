using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System.Text;

class Subscriber
{
    [Obsolete]
    static async Task Main()
    {
        Console.WriteLine("[ MQTT Subscriber v1 ]");
        Console.WriteLine("Received messages:");

        MqttFactory mqttFactory = new();

        IMqttClient client = mqttFactory.CreateMqttClient();

        IMqttClientOptions options = new MqttClientOptionsBuilder()
            .WithClientId(Guid.NewGuid().ToString())
            .WithTcpServer("test.mosquitto.org", 1883)
            .WithCleanSession()
            .Build();

        client.UseConnectedHandler(async e =>
        {
            MqttTopicFilter topicFilter = new TopicFilterBuilder()
                .WithTopic("IaroslavOs")
                .Build();

            await client.SubscribeAsync(topicFilter);
        });

        client.UseApplicationMessageReceivedHandler(e =>
        {
            try
            {
                string message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                Console.WriteLine($"{DateTime.Now}: {message}");
            } 
            catch {}
        });

        await client.ConnectAsync(options);

        Console.ReadLine();

        await client.DisconnectAsync();
         
    }
}