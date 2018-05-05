using System;

public class StartUp
{
    static void Main(string[] args)
    {
        var dateDiff = new DateModifier();

        var d1 = Console.ReadLine();
        var d2 = Console.ReadLine();
        dateDiff.CalculateDiff(d1, d2);
        Console.WriteLine(dateDiff.DifferenceInDays);
    }
}

