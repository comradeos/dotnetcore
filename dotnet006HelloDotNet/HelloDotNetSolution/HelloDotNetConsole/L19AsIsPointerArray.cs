namespace HelloDotNetConsole; 
using static L00Tools;

public class C191 {
    public int number;
}


public class C192:C191 {
    public string word;
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

        foreach (var item in c191List) {
            Console.WriteLine(item.number);
        }
        
        
        Line();
        
        var strList = new List<string>() {
            "aaa",
            "bbb",
            "ccc",
        };

        Console.WriteLine(strList[0]);
        strList.Add("ddd");
        Console.WriteLine(strList[3]);
        
        Line();
        
        // AS
        var c1921 = new C192();
        c1921.number = 231;
        c1921.word = "word";
        var obj = c1921 as C191; // использовать c1921 как єкземпляр C191




    }    
}