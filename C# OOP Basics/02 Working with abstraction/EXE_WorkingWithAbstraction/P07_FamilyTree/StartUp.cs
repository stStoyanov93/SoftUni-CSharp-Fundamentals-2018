using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    public class StartUp
    {
        static void Main(string[] args)
        {           
            var personInput = Console.ReadLine();
            var headPerson = Person.CreateCentralPerson(personInput);
            var familyTree = new List<Person>();
            familyTree.Add(headPerson);

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var inputParams = input.Split(" - ");

                if (inputParams.Length > 1)
                {
                    var firstParam = inputParams[0];
                    var secondParam = inputParams[1];

                    Person currentPerson;

                    if (Person.IsBirthday(firstParam))
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Birthday == firstParam);

                        if (currentPerson == null)
                        {
                            currentPerson = new Person { Birthday = firstParam };
                            familyTree.Add(currentPerson);
                        }

                        SetChild(familyTree, currentPerson, secondParam);
                    }
                    else
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Name == firstParam);

                        if (currentPerson == null)
                        {
                            currentPerson = new Person { Name = firstParam };
                            familyTree.Add(currentPerson);
                        }

                        SetChild(familyTree, currentPerson, secondParam);
                    }
                }
                else
                {
                    inputParams = inputParams[0].Split();
                    var name = $"{inputParams[0]} {inputParams[1]}";
                    var birthday = inputParams[2];

                    var person = familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

                    if (person == null)
                    {
                        person = new Person(name, birthday);
                        familyTree.Add(person);
                    }

                    person.Name = name;
                    person.Birthday = birthday;

                    int index = familyTree.IndexOf(person) + 1;
                    int count = familyTree.Count - index;

                    Person[] copy = new Person[count];
                    familyTree.CopyTo(index, copy, 0, count);

                    Person copyPerson = copy.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

                    if (copyPerson != null)
                    {
                        copyPerson.Birthday = birthday;
                        familyTree.Remove(copyPerson);
                        person.Parents.AddRange(copyPerson.Parents);
                        person.Parents = person.Parents.Distinct().ToList();

                        person.Children.AddRange(copyPerson.Children);
                        person.Children = person.Children.Distinct().ToList();
                    }
                }
            }

            PrintTree(headPerson);
        }

        private static void SetChild(List<Person> familyTree, Person parent, string childInfo)
        {
            var child = new Person();

            if (Person.IsBirthday(childInfo))
            {
                if (!familyTree.Any(p => p.Birthday == childInfo))
                {
                    child.Birthday = childInfo;
                }
                else
                {
                    child = familyTree.First(p => p.Birthday == childInfo);
                }
            }
            else
            {
                if (!familyTree.Any(p => p.Name == childInfo))
                {
                    child.Name = childInfo;
                }
                else
                {
                    child = familyTree.First(p => p.Name == childInfo);
                }
            }

            parent.Children.Add(child);
            child.Parents.Add(parent);
            familyTree.Add(child);
        }

        private static void PrintTree(Person mainPerson)
        {
            Console.WriteLine(mainPerson);

            Console.WriteLine("Parents:");

            foreach (var p in mainPerson.Parents)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Children:");

            foreach (var c in mainPerson.Children)
            {
                Console.WriteLine(c);
            }
        }     
    }
}
