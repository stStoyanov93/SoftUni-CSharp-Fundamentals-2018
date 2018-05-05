using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();

            string animal;

            while ((animal = Console.ReadLine()) != "Beast!")
            {
                var inputParams = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                try
                {
                    var name = inputParams[0];
                    var age = int.Parse(inputParams[1]);
                    var gender = inputParams[2];

                    CreateAnimal(animals, animal, name, age, gender);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var a in animals)
            {
                Console.WriteLine(a.ToString());
            }
        }

        private static void CreateAnimal(List<Animal> animals, string animal, string name, int age, string gender)
        {
            Animal currentAnimal;

            switch (animal)
            {
                case "Cat":
                    currentAnimal = new Cat(name, age, gender);
                    animals.Add(currentAnimal);
                    break;
                case "Kitten":
                    currentAnimal = new Kitten(name, age, gender);
                    animals.Add(currentAnimal);
                    break;
                case "Tomcat":
                    currentAnimal = new Tomcat(name, age, gender);
                    animals.Add(currentAnimal);
                    break;
                case "Dog":
                    currentAnimal = new Dog(name, age, gender);
                    animals.Add(currentAnimal);
                    break;
                case "Frog":
                    currentAnimal = new Frog(name, age, gender);
                    animals.Add(currentAnimal);
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        }
    }
}
