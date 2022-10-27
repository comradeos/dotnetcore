namespace HelloDotNetConsole;

using static L00Tools;

public class L18A {
    private int _numValue;

    public L18A(int numValue) {
        this._numValue = numValue;
    }

    public void SetValue(int newValue) {
        this._numValue = newValue;
    }

    public void PrintValue() {
        Console.WriteLine(this._numValue);
    }
    
}



public static class L18Inheritance {
    public static void Run() {
    }
}