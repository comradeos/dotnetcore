public delegate void MD(); 

public class Delegates
{
    public static void Run()
    {
        MD md = new(Message);
        md += Message;
        md += Message;
        md += Message;
        md -= Message;
        md -= Message;
        md -= Message;
        md();
    }

    public static void Message() 
    {
        Console.WriteLine("message");
    }
}