namespace HelloDotNetConsole; 
using static L00Tools;

public class C191 {
    public int number;
}


public static class L19AsIsPointerArray {
    public static void Run() {
        var c1911 = new C191() {
            number = 111,
        };
        var c1912 = new C191() {
            number = 222,
        };
        var c1913 = new C191() {
            number = 333,
        };

        var c191List = new List<C191>();
        c191List.Add(c1911);
        c191List.Add(c1912);
        c191List.Add(c1913);

        Console.WriteLine(c191List[0].number);
        Console.WriteLine(c191List[1].number);
        Console.WriteLine(c191List[2].number);
    }    
}