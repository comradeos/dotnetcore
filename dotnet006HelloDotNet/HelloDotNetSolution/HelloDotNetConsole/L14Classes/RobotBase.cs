namespace HelloDotNetConsole.L14Classes;

public class RobotBase {
    private string _name;
    private int _weight;
    private int[] _coordinates;

    public void SetValues(string name, int weight, int[] coordinates) {
        _name = name;
        _weight = weight;
        _coordinates = coordinates;
    }

    public void PrintValues() {
        Console.WriteLine(_name);
        Console.WriteLine(_weight);

        foreach (var item in _coordinates) {
            Console.WriteLine(item);
        }
    }
}