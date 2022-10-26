namespace HelloDotNetConsole;

public class Robot {
    private string _name;
    private int _weight;
    private int[] _coordinates;

    public Robot(string name, int weight, int[] coordinates) {
        _name = name;
        _weight = weight;
        _coordinates = coordinates;
    }

    public void SetValues(string newName, int newWeight, int[] newCoordinates) {
        _name = newName;
        _weight = newWeight;
        _coordinates = newCoordinates;
    }
    
    

}

public static class L15ConstructStatic {
    public static void Run() {
        
    }
}