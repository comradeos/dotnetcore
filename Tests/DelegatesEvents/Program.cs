/*
https://www.youtube.com/watch?v=pP24DbV0uCc
https://www.youtube.com/watch?v=oDucgj1JDPQ
*/

public class Program
{
    delegate int MyDelegate(int a, int b); /*тип, который хранит ссылку на метод*/

    static int Sum(int a, int b) { return a + b; }

    public static void Main()
    {
        MyDelegate myDelegate = new(Sum);
        Console.WriteLine(myDelegate(1,2));

        Example2 example2 = new();
        Delegate2 delegate2 = new(example2.ShowMessage1);
        delegate2 += example2.ShowMessage2;
        delegate2();

        // ------------------------------------------------------------------

        EventExample eventExample = new();
        eventExample.Run();

        // ------------------------------------------------------------------

        Example3 example3 = new();
        example3.Run();
    }

}