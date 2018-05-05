using System;

namespace P01_02_DefineAnInterfaceIPerson
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //P01
            //string name = Console.ReadLine();
            //int age = int.Parse(Console.ReadLine());
            //IPerson person = new Citizen(name, age);

            //Console.WriteLine(person.Name);
            //Console.WriteLine(person.Age);

            //P02
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var id = Console.ReadLine();
            var birthdate = Console.ReadLine();

            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);

            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);
        }
    }
}
