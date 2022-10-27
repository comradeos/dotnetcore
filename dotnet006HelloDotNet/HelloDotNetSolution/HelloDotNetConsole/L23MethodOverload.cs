namespace HelloDotNetConsole;

public class C23 {
    protected int Num { set; get; }

    public C23(int num) {
        this.Num = num;
    }

    public void PrintNum() {
        Console.WriteLine(this.Num);
    }
}

public class D23 : C23 {
    public D23(int num) : base(num) {
    }

    public void PrintNum(int value) {
        Console.WriteLine(this.Num * value);
    }

    public new void PrintNum() {
        Console.WriteLine("AAAAAA " + this.Num);
    }
}

public static class L23MethodOverload {
    public static void Run() {
        var c1 = new C23(5);
        c1.PrintNum();
        var d1 = new D23(5);
        d1.PrintNum(313);
        d1.PrintNum();
    }
}