namespace HelloDotNetConsole;

using static L00Tools;

public abstract class A21Abstract {
    protected string Name;
    protected int Age;

    protected A21Abstract(string name, int age) {
        this.Name = name;
        this.Age = age;
    }

    public abstract void SetName(string name);
    public abstract void SetAge(int age);
    public abstract void PrintName();
    public abstract void PrintAge();

    public void PrintData() {
        Console.WriteLine("Name: " + this.Name + "\nAge: " + this.Age);
    }
}

public class A21 : A21Abstract {
    public A21(string name, int age) : base(name, age) {
    }

    public override void SetName(string name) {
        this.Name = name;
    }

    public override void SetAge(int age) {
        this.Age = age;
    }

    public override void PrintName() {
        Console.WriteLine(this.Name);
    }

    public override void PrintAge() {
        Console.WriteLine(this.Age);
    }
}

public static class L21AbstractClassesMethods {
    public static void Run() {
        var a = new A21("CoolName", 5123);
        a.PrintData();
    }
}