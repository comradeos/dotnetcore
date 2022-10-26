namespace HelloDotNetConsole;

using static L00Tools;


public class L18A {
    private int _numValue;

    public int _Numvalue {
        get {
            Console.WriteLine("<<< get _numValue");
            return 7;
        }
        set {
            Console.WriteLine(">>> set _numValue");
            this._numValue = value;
        }
    }
    public L18A(int numValue) {
        this._numValue = numValue;
    }
}

public static class L18Inheritance {
    public static void Run() {
      
    }
}