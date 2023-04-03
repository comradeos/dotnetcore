using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

// MqttClient client = new("miqottt.com");
// client.Connect("inoqos", "inoqos@gmail.com", "_inq99447MQ");

MqttClient client = new("test.mosquitto.org");
client.Connect(Guid.NewGuid().ToString());

if (client.IsConnected)
{
    Console.WriteLine("connected");
}

client.MqttMsgPublished += client_MqttMsgPublished;

while (true)
{
    Console.WriteLine("Input some");
    string? msg = Console.ReadLine() ?? "";
    client.Publish("InoqosTopic0", Encoding.UTF8.GetBytes(msg), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
}

static void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
{
    Console.WriteLine("Message Published");
    Console.WriteLine(e.IsPublished);
    Console.WriteLine(e.MessageId);
}