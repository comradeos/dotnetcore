namespace HelloDotNetConsole;

using Tools = L00Tools;
using RobotBase = L14Classes.RobotBase;

public static class L14ClassesObjects {
    public static void Run() {
        Tools.Line();

        var bot1 = new RobotBase();
        bot1.name = "MR1";
        bot1.weight = 987;
        bot1.coordinates = new[] {
            0, 0, 0,
        };
        
    }
}