public static class Program {

    public static int DivByZero(int a, int b) {
        return a / b;
    }

    public static void Main()
    {
        try {
            int result = DivByZero(1, 0); 
            Console.WriteLine(result);
        } catch (Exception e) {
            Console.WriteLine($"шось не так: {e}");
        }
    }
}