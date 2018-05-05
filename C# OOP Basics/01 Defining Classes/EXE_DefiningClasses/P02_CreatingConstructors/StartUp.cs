using System;


public class StartUp
{
    static void Main(string[] args)
    {
        var p1 = new Person();
        var p2 = new Person(8);
        var p3 = new Person(4, "Pesho");

        Console.WriteLine($"{p1.Name} is {p1.Age}");
        Console.WriteLine($"{p2.Name} is {p2.Age}");
        Console.WriteLine($"{p3.Name} is {p3.Age}");
    }
}

