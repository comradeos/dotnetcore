// dotnet new console --name <myapp>
// dotnet run
// dotnet build
// dotnet publish

class Program 
{
    static void ShowMessage()
    {
        for (int i=0; i<5; ++i)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Message #{i}");
        }
    }

    static async Task ShowMessageAsync()
    {
        await Task.Run(()=>{
            ShowMessage();
        });
    }

    static async Task<string> GetStringValueAsync()
    {
        await Task.Run(()=>{
            for (int i=0; i < 5; ++i)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"wait for it...");
            }
        });

        return "HERE WE GO!";
    }



    public static void Main()
    {
        Console.WriteLine("async/await");

        ShowMessageAsync();
        //Task<string> myString = GetStringValueAsync();

        while (true)
        {
            Thread.Sleep(500);
            Console.WriteLine(".....");
            Console.WriteLine(ShowMessageAsync().Status);
        } 
    }
}