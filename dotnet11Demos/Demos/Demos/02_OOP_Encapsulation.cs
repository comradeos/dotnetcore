namespace Demos;

class Bank
{
    private int _balance;
    private readonly Lock _lock = new();
    
    public Bank(int balance)
    {
        if (balance < 0)
        {
            throw new ArgumentException("Balance cannot be negative");
        }
        
        _balance = balance;
    }

    public void Deposit(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }

        lock (_lock)
        {
            _balance += amount;
        }
    }

    public void Withdraw(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }
        
        lock (_lock)
        {
            if (amount > _balance)
            {
                throw new ArgumentException("Insufficient balance");
            }
            
            _balance -= amount;
        }
    }
    
    public int GetBalance()
    {
        lock (_lock)
        {
            return _balance;
        }
    }
}

public static class Encapsulation
{
    public static void Demo()
    {
        Bank bank = new(100);
        bank.Deposit(100);
        bank.Withdraw(10);
        Console.WriteLine(bank.GetBalance());
    }
}

