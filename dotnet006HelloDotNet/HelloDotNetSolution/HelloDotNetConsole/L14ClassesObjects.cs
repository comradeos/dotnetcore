namespace HelloDotNetConsole;

using Tools = L00Tools;
using RobotBase = L14Classes.RobotBase;

public static class L14ClassesObjects {
    public static void Run() {
        Tools.Line();

        var bot1 = new RobotBase();
        bot1.SetValues("B1", 231, new int [] {
            4,1,2,
        });
        bot1.PrintValues();
        
    }
}