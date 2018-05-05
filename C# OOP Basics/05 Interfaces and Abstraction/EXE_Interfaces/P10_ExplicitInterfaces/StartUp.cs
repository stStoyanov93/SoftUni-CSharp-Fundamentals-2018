using System;
using System.Collections.Generic;

namespace P10_ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var citizens = new List<Citizen>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var inputParams = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var name = inputParams[0];
                var country = inputParams[1];
                var age = int.Parse(inputParams[2]);

                citizens.Add(new Citizen(name, country, age));               
            }

            foreach (var citizen in citizens)
            {
                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
