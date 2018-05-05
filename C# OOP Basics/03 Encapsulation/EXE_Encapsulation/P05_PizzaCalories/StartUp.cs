using System;

namespace P05_PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Pizza pizza;
            //Dough dough;

            try
            {
                var pizzaParams = Console.ReadLine().Split();
                Pizza pizza = new Pizza(pizzaParams[1]);

                var doughParams = Console.ReadLine().Split();
                var flourType = doughParams[1];
                var bakingType = doughParams[2];
                var weight = double.Parse(doughParams[3]);

                Dough dough = new Dough(flourType.ToLower(), bakingType.ToLower(), weight);

                pizza.PizzaDough = dough;

                string input;

                while ((input = Console.ReadLine()) != "END")
                {
                    var toppingParams = input.Split();

                    var toppingName = toppingParams[1].ToLower();
                    var toppingWeight = double.Parse(toppingParams[2]);
                    var topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
