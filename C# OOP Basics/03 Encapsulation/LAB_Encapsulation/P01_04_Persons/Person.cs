using System;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }

            this.lastName = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }

            this.age = value;
        }
    }

    public decimal Salary
    {
        get
        {
            return this.salary;
        }
        private set
        {
            if (value < 460m)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }

            this.salary = value;
        }
    }

    public void IncreaseSalary (decimal percentage)
    {
        var bonusMoney = this.salary * (percentage / 100);

        if (this.Age > 30)
        {
            this.salary += bonusMoney;
        }
        else
        {
            this.salary += bonusMoney / 2;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.salary:F2} leva.";
    }

    //for problem 1
    //public override string ToString()
    //{
    //    return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
    //}
}