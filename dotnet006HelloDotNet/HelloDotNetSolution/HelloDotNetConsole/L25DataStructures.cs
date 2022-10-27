namespace HelloDotNetConsole;

public struct SBook {
    private string _author, _title;

    public SBook(string author, string title) {
        this._author = author;
        this._title = title;
    }
    
    public void SetAuthor(string value) {
        this._author = value;
    }
    
    public void PrintAuthor() {
        Console.WriteLine(this._author);
    }

    public void SetTitle(string value) {
        this._title = value;
    }
    
    public void PrintTitle() {
        Console.WriteLine(this._title);
    }

}

public static class L25DataStructures {
    public static void Run() {
        var b1 = new SBook("PVO", "GKBT");
        b1.SetAuthor("Виктор Пелевин");
        b1.SetTitle("KGBT+");
        b1.PrintAuthor();
        b1.PrintTitle();
    }
}