using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {          
            var people = new List<Person>();
            var products = new List<Product>();

            try
            {
                var input = Console.ReadLine()
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var personInfo in input)
                {
                    var personParams = personInfo.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                    var name = personParams[0];
                    var money = decimal.Parse(personParams[1]);

                    var person = new Person(name, money);
                    people.Add(person);
                }

                input = Console.ReadLine()
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var productInfo in input)
                {
                    var productParams = productInfo.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                    var name = productParams[0];
                    var cost = decimal.Parse(productParams[1]);

                    var product = new Product(name, cost);
                    products.Add(product);
                }

                string line;

                while ((line = Console.ReadLine()) != "END")
                {
                    var lineParams = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var personName = lineParams[0];
                    var productName = lineParams[1];

                    var person = people.Where(p => p.Name == personName).FirstOrDefault();
                    var product = products.Where(p => p.Name == productName).FirstOrDefault();

                    if (person.Money < product.Cost)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                    else
                    {
                        person.AddProduct(product);
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                }

                foreach (var person in people)
                {
                    var result = person.Products
                        .Any()
                        ? string.Join(", ", person.Products.Select(x => x.Name).ToList())
                        : "Nothing bought";

                    Console.WriteLine($"{person.Name} - {result}");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
