using System;
using System.Collections.Generic;

public class Person
{
    public Person()
    {      
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }

    public Person(string name, string birthday)
        :this()
    {
        this.Name = name;
        this.Birthday = birthday;
    }

    public string Name { get; set; }

    public string Birthday { get; set; }

    public List<Person> Parents { get; set; }

    public List<Person> Children { get; set; }

    public static Person CreateCentralPerson(string input)
    {
        var person = new Person();

        if (IsBirthday(input))
        {
            person.Birthday = input;
        }
        else
        {
            person.Name = input;
        }

        return person;
    }

    public static bool IsBirthday(string input)
    {
        return Char.IsDigit(input[0]);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}
