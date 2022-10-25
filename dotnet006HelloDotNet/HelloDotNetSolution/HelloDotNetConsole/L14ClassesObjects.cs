namespace HelloDotNetConsole;

using Tools = L00Tools;
using RobotBase = L14Classes.RobotBase;


public static class L14ClassesObjects {
    public static void Run() {
        Tools.Line();
        var r1 = new RobotBase("a", "b");
        r1.PrintType();
        r1.PrintModel();
    }
}