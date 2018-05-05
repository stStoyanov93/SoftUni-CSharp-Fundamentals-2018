using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main(string[] args)
    {
        var accounts = new Dictionary<int, BankAccount>();
        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            var splittedCommand = command.Split();
            var accountId = int.Parse(splittedCommand[1]);

            switch (splittedCommand[0])
            {
                case "Create":
                    if (accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account already exists");
                    }
                    else
                    {
                        accounts.Add(accountId, new BankAccount() { Id = accountId});
                    }
                    break;
                case "Deposit":
                    var amount = decimal.Parse(splittedCommand[2]);

                    if (!accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {                      
                        accounts[accountId].Deposit(amount);
                    }
                    break;
                case "Withdraw":
                    var withdrawAmount = decimal.Parse(splittedCommand[2]);

                    if (!accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else if (accounts[accountId].Balance < withdrawAmount)
                    {
                        Console.WriteLine("Insufficient balance");
                    }
                    else
                    {
                        accounts[accountId].Withdraw(withdrawAmount);
                    }
                    break;
                case "Print":
                    if (!accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        Console.WriteLine(accounts[accountId].ToString());
                    }
                    break;
            }
        }
    }
}

