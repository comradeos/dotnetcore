namespace HelloDotNetConsole;

public class Robot {
    // https://metanit.com/sharp/tutorial/3.2.php модификаторы доступа
    private static int counter = 0;
    private string _name;
    private int _weight;
    private int[] _coordinates;
    
    /**
     * Конструктор для нового объекта.
     */
    public Robot(string name, int weight, int[] coordinates) {
        _name = name;
        _weight = weight;
        _coordinates = coordinates;
        Console.WriteLine("Робот " + _name + " создан!");
        ++counter;
    }

    /**
     * Второй конструктор.
     */
    public Robot() {
        ++counter;
    }
    
    /**
     * Установка новых значений для имени веса и координат.
     */
    public void SetValues(string newName, int newWeight, int[] newCoordinates) {
        _name = newName;
        _weight = newWeight;
        _coordinates = newCoordinates;
    }
    
    /**
     * Вывод значений полей в терминал.
     */
    public void PrintValues() {
        Console.WriteLine("Robot Info:");
        Console.WriteLine("Name: " + _name);
        Console.WriteLine("Weight: " + _weight + "kg.");
        
        Console.Write("Current coordinates: ");
        for (var i = 0; i < _coordinates.Length; ++i) {
            Console.Write(_coordinates[i]);
            if (i < _coordinates.Length - 1) {
                Console.Write(", ");
            }
            else {
                Console.WriteLine();
            }
        }
    }
    
    /**
     * Отобразить количество созданных объектов. 
     */
    public static void PrintCounter() {
        Console.WriteLine("Созданно роботов " + counter + " шт.");
    }
    
}

public static class L15ConstructStatic {
    public static void Run() {
        var abot = new Robot("AB1", 512, new[] { 42, 12, 52, });
        abot.PrintValues();        
        
        var bbot = new Robot();
        bbot.SetValues("BB1", 224, new [] { 9, 1, 4, });
        bbot.PrintValues();        
        
        var сbot = new Robot();

        Robot.PrintCounter();
    }
}