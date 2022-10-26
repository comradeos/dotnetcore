namespace HelloDotNetConsole;


public class L16A {
    private string _strValue;
    private int _numValue;

    public L16A(string strValue, int numValue) {
        this._strValue = strValue;
        this._numValue = numValue;
    }

    public void SetValues(string strValue, int numValue) {
        this._strValue = strValue;
        this._numValue = numValue;
    }
    public void GetValues(string strValue, int numValue) {
        Console.WriteLine(this._strValue);
        Console.WriteLine(this._numValue);
    }
    
}


public static class L16This {
    public static void Run() {
        
    }
}