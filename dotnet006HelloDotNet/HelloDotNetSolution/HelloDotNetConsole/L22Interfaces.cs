namespace HelloDotNetConsole;

public interface I22 {
    string name { set; get; }
    int age { set; get; }
    void GetData();
}

public abstract class A22 {
    protected string strValue;
    protected int intValue;
    public abstract void SetData(string s, int i);
}

public class B22 : A22, I22 {
    public override void SetData(string s, int i) {
        this.strValue = s;
        this.intValue = i;
    }

    public string name { get; set; }
    public int age { get; set; }
    public void GetData() {
        Console.WriteLine(this.name + this.age);
    }
}

public static class L22Interfaces {
    public static void Run() {
        var b1 = new B22();
        b1.SetData("bstr", 232);
        b1.name = "aaaa";
        b1.age = 444;
        b1.GetData();
    }
}