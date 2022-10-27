namespace HelloDotNetConsole;

using static L00Tools;

public class C24 {
    public enum UsbType {
        TypeA,
        TypeB,
        TypeC,
    }

    public UsbType Utype;

    public C24(UsbType type) {
        this.Utype = type;
    }

    public void PrintType() {
        Console.WriteLine(this.Utype);
    }
}

public static class L24Enums {
    public static void Run() {
        var c1 = new C24(C24.UsbType.TypeA);
        c1.PrintType();
        Line();

        c1.Utype = C24.UsbType.TypeB;
        c1.PrintType();
        Line();

        c1.Utype = C24.UsbType.TypeC;
        c1.PrintType();
        Line();
    }
}