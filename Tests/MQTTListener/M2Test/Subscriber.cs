using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

// MqttClient client = new("miqottt.com");
// client.Connect("inoqos", "inoqos@gmail.com", "_inq99447MQ");

MqttClient client = new("test.mosquitto.org");
client.Connect(Guid.NewGuid().ToString());



client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

if (client.IsConnected)
{
    Console.WriteLine("connected");
}

client.Subscribe(new string[] { "InoqosTopic0" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
{
    Console.WriteLine(Encoding.UTF8.GetString(e.Message));
}