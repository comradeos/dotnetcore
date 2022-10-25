namespace HelloDotNetConsole;

using Tools = L00Tools;

internal class Robot {
    private string _type;
    private string _model;

    public Robot(string model, string type) {
        this._model = model;
        this._type = type;
    }

    public void SetType(string newType) {
        this._type = newType;
    }

    public void PrintType() {
        Console.WriteLine(this._type);
    }

    public void SetModel(string newModel) {
        this._model = newModel;
    }

    public void PrintModel() {
        Console.WriteLine(this._model);
    }
}

public static class L14ClassesObjects {
    public static void Run() {
        Tools.Line();
        var robot1 = new Robot("D97", "Delivery");
        robot1.PrintType();
        robot1.PrintModel();
    }
}