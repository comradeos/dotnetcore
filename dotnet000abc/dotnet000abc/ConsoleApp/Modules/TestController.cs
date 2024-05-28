namespace ConsoleApp.Modules;

public class TestController
{
    public static void Test()
    {
        List<DeviceToService> list = [];
        
        DeviceToService device1 = new()
        {
            SerialNumber = "serial1",
            Bunkers = new()
            {
                new()
                {
                    BunkerNumber = 1,
                    IngredientName = "Кава Якобс",
                    Amount = 5,
                    Unit = "кг"
                },
                new()
                {
                    BunkerNumber = 2,
                    IngredientName = "Цукор",
                    Amount = 3,
                    Unit = "кг"
                },
                new()
                {
                    BunkerNumber = 3,
                    IngredientName = "Молоко",
                    Amount = 3,
                    Unit = "л"
                }
            }
        };     
        
        DeviceToService device2 = new()
        {
            SerialNumber = "serial2",
            Bunkers = new()
            {
                new()
                {
                    BunkerNumber = 1,
                    IngredientName = "Кава Нескафе",
                    Amount = 5,
                    Unit = "кг"
                },
                new()
                {
                    BunkerNumber = 2,
                    IngredientName = "Стакан",
                    Amount = 300,
                    Unit = "шт"
                },
                new()
                {
                    BunkerNumber = 3,
                    IngredientName = "Вода",
                    Amount = 70,
                    Unit = "л"
                }
            }
        };
        
        list.Add(device1);
        list.Add(device2);
        
        Console.WriteLine("----------------");
        Console.WriteLine("A - 1");
        Console.WriteLine("B - 2");
        Console.WriteLine("C - 3");
        Console.WriteLine("----------------");
        
        Dictionary<string, int> data = new()
        {
            {"A", 1},
            {"B", 2},
            {"C", 3}
        };

        Console.WriteLine("----------------");
        foreach (var item in data)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
        Console.WriteLine("----------------");
    }
}



class BunkerToService
{
    public int BunkerNumber { get; set; } = default!;
    public string IngredientName { get; set; }  = default!;
    public decimal Amount { get; set; }
    public string Unit { get; set; }  = default!;
}

class DeviceToService
{
    public string SerialNumber { get; set; } = default!;
    
    public string LocationAddress { get; set; } = default!;
    public List<BunkerToService> Bunkers { get; set; } = [];
}