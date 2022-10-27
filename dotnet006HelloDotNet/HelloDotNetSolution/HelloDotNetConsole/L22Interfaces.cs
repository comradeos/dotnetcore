namespace HelloDotNetConsole;

public interface I22 {
    string Name { set; get; }
    int Age { set; get; }
    void GetData();
}

public abstract class A22 {
    protected string StrValue;
    protected int IntValue;
    public abstract void SetData(string s, int i);
}

public class B22 : A22, I22 {
    public override void SetData(string s, int i) {
        this.StrValue = s;
        this.IntValue = i;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public void GetData() {
        Console.WriteLine(this.Name + this.Age);
    }
}

public static class L22Interfaces {
    public static void Run() {
        var b1 = new B22();
        b1.SetData("bstr", 232);
        b1.Name = "aaaa";
        b1.Age = 444;
        b1.GetData();
    }
}