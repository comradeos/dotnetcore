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
    private readonly int _additionalNumber;

    public L18B(int numValue, int addNum) : base(numValue) {
        this._additionalNumber = addNum;
    }

    public void PrintAddNum() {
        Console.WriteLine(this._additionalNumber);
    }
}

public static class L18Inheritance {
    public static void Run() {
        var l18A = new L18A(7);
        var l18B = new L18B(8, 9);
        l18A.PrintValue(); // 7
        l18B.PrintValue(); // 8
        l18B.PrintAddNum(); // 9
        Line();
    }
}