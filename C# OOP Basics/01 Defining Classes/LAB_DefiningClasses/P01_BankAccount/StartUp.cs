using System;

public class StartUp
{
    static void Main(string[] args)
    {
        var acc = new BankAccount();
        acc.Id = 1;
        acc.Balance = 15;

        Console.WriteLine($"Account {acc.Id}, balance {acc.Balance}");
    }
}

