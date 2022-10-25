namespace HelloDotNetConsole;

using Tools = L00Tools;

class Robot {
    private string type;
    private string model;

    public void SetType(string type) {
        this.type = type;
    }

    public void PrintType() {
        Console.WriteLine(this.type);
    }

    private void PrintModel() {
        Console.WriteLine(this.model);
    }
}

public static class L14ClassesObjects {
    public static void Run() {
        Tools.Line();
        var robot1 = new Robot();
        robot1.SetType("Delivery");
        robot1.PrintType();
        
        
    }
}