using System;

public class StartUp
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var calculator = new PriceCalculator();
        calculator.CalculatePrice(input);
        calculator.PrintPrice();
    }
}

