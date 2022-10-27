namespace HelloDotNetConsole; 
using static L00Tools;

public class A20 {
    protected int num;

    public void SetNum(int num) {
        this.num = num;
    }
    
    public virtual void PrintNum() {
        Console.WriteLine(this.num);
    }
    
}

public class B20 : A20 {
    public override void PrintNum() {
        Console.WriteLine(">>> " + this.num);
    }
}

public static class L20VirtualMethods {
    public static void Run() {
        var a = new A20();
        a.SetNum(34);
        a.PrintNum();
        
        var b = new B20();
        b.SetNum(55);
        b.PrintNum();
    }
}