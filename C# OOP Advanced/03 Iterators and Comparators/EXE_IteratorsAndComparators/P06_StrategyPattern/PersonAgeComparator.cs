using System.Collections.Generic;

public class PersonAgeComperator : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        var value = firstPerson.Age.CompareTo(secondPerson.Age);
        return value;
    }
}