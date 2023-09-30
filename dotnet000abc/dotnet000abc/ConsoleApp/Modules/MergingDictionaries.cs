namespace ConsoleApp.Modules;

public class MergingDictionaries
{
    public static void Test()
    {
        Dictionary<string, int> d1 = new()
        {
            { "a", 1 },
            { "b", 2 },
            { "c", 3 }
        };

        Dictionary<string, int> d2 = new()
        {
            { "a", 1 },
            { "b", 2 },
            { "d", 4 }
        };

        foreach (var i in d2)
        {
            if (d1.ContainsKey(i.Key))
            {
                continue;
            }
            d1.Add(i.Key, i.Value);
        }
        
        foreach (var i in d1)
        {
            Console.WriteLine($"i.Key {i.Key} i.Value {i.Value}");
        }
    }   
}