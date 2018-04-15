using System;

public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public int CompareTo(Person other)
    {
        var result = this.Name.CompareTo(other.Name);

        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }

        return result;
    }

    public override bool Equals(object obj)
    {
        if (this.CompareTo((Person)obj) != 0)
        {
            return false;
        }
        return true;
    }

    public override int GetHashCode()
    {
        var hashCode = this.Name.GetHashCode() + this.Age.GetHashCode();
        return hashCode;
    }
}