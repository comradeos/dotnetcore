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

// ------------------------------------------------------------------------------

public abstract class AMan {
    private string Name { set; get; }
    private int Age { set; get; }

    protected AMan(string name, int age) {
        this.Name = name;
        this.Age = age;
    }

    public abstract void SelfIntroduce();
}

public class CPerson : AMan, IWalk, IRun {
    private string Name { set; get; }
    private int Age { set; get; }

    public CPerson(string name, int age) : base(name, age) {
        this.Name = name;
        this.Age = age;
    }

    public override void SelfIntroduce() {
        Console.WriteLine("Hello, my name is " + this.Name + "\nI'm " + this.Age + " years old!");
    }

    public void Walking() {
        Console.WriteLine(this.Name + " is walking...");
    }
    
    public void Running() {
        Console.WriteLine(this.Name + " is running!!!");
    }
}

public interface IWalk {
    void Walking();
}

public interface IRun {
    void Running();
}

// ------------------------------------------------------------------------------

public static class L22Interfaces {
    public static void Run() {
        // var b1 = new B22();
        // b1.SetData("bstr", 232);
        // b1.Name = "aaaa";
        // b1.Age = 444;
        // b1.GetData();
        var c1 = new CPerson("NAME", 777);
        c1.SelfIntroduce();
        c1.Walking();
        c1.Running();
    }
}