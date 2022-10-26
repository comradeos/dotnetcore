namespace HelloDotNetConsole; 


public class L17A {
    private string _strValue;
    private int _numValue;
    
    // Аксессор
    public int _Numvalue {
        get {
            Console.WriteLine(" <<< get");
            return 51515;
        }
        set {
            Console.WriteLine(" >>> set");
            this._numValue = value;
        }
    }

    // возсожность получать но невозможность устанавливать вне класса
    public string _Strvalue { get; private set; }


    public L17A(string strValue, int numValue) {
        this._strValue = strValue;
        this._numValue = numValue;
    }

    public void SetValues(string strValue, int numValue) {
        this._strValue = strValue;
        this._numValue = numValue;
    }
    public void PrintValues() {
        Console.WriteLine(this._strValue);
        Console.WriteLine(this._numValue);
    }
    
}

public static class L17AccessorsGetSet {
    public static void Run() {
        var l17A1 = new L17A("STR", 777);
        var n = l17A1._Numvalue;
        Console.WriteLine(n);
                
        l17A1._Numvalue = 434444;
        l17A1.PrintValues();
        
        

    }
}