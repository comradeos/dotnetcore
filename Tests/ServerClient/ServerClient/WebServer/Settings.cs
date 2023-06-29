using System.Xml.Linq;

namespace WebServer;

public class Settings
{
    public static Dictionary<string, string> Addresses = new()
    {
        { "101", "http://127.0.0.1:8888" },
        { "102", "http://127.0.0.1:8889" }
    };
}
