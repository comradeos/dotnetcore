using NetCoreConsole.Controllers;

namespace NetCoreConsole;

public static class Program {
    public static void Main() {
        Console.WriteLine("Program->Main");
        BaseController.Run();
    }
}
