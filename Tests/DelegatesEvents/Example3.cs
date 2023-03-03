public class Example3
{
    public delegate void Example3Delegate();
    public event Example3Delegate Example3Event; 

    public void ShowMessage() => Console.WriteLine("message");
    
    public void Run()
    {
        Example3Event += ShowMessage;
        Example3Event();
    }
} 