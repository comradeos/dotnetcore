public delegate void MyDelegateName(string a, int b);

public class EventExample
{
    public event MyDelegateName MyEventName;

    public void MyMethodName(string param1, int param2)
    {
        Console.WriteLine($"{param1}, {param2}");
    }

    public void Run()
    {
        this.MyEventName += MyMethodName;
        this.MyEventName("aaa", 123);
    }
}
