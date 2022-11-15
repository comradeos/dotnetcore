class StockExchangeMonitor
{
    public delegate void PriceChange(int price);
    public PriceChange PriceChangeHandler { get; set; } = ShowPrice;

    public void Start()
    {
        while (true)
        {
            int bankOfAmericaPrice = (new Random().Next(100));
            PriceChangeHandler(bankOfAmericaPrice);
            Thread.Sleep(2000);
        }
    }
    public static void ShowPrice(int price)
    {
        Console.WriteLine($"New price is ${price}");
    }
}

public static class Program
{
    public static void Main()
    {
        StockExchangeMonitor monitor = new();
        monitor.Start();
    }
}