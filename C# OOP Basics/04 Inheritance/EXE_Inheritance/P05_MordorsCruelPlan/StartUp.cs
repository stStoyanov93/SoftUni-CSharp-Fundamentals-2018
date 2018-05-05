using System;

namespace P05_MordorsCruelPlan
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var foodInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var gandalf = new Gandalf();
            var foodFactory = new FoodFactory();

            foreach (var tyoeOfFood in foodInput)
            {
                var food = foodFactory.CreateFood(tyoeOfFood);
                gandalf.Eat(food);
            }

            Console.WriteLine(gandalf);
        }
    }
}
