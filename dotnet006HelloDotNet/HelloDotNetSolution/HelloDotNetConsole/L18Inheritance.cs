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

public class L18B : L18A {
    public L18B(int numValue) : base(numValue) {
    }
}

public static class L18Inheritance {
    public static void Run() {
        var l18A = new L18A(7);
        var l18B = new L18B(8);
        l18A.PrintValue(); // 7
        l18B.PrintValue(); // 8
        Line();
    }
}