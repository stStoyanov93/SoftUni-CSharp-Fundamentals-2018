using System;

public class Chicken
{
    public const int MIN_AGE = 0;
    public const int MAX_AGE = 15;

    private string name;
    private int age;

    public Chicken(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            this.name = value;
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
            if (value < MIN_AGE || value > MAX_AGE)
            {
                throw new ArgumentException($"Age should be between {MIN_AGE} and {MAX_AGE}.");
            }

            this.age = value;
        }
    }

    public double ProductPerDay => this.CalculateProductPerDay();

    public double CalculateProductPerDay()
    {
        if (this.Age <= 3)
        {
            return 1.5;
        }
        else if (this.Age <= 7)
        {
            return 2;
        }
        else if (this.Age <= 11)
        {
            return 1;
        }
        else
        {
            return 0.75;
        }
    }

    public override string ToString()
    {
        return $"Chicken {this.Name} (age {this.Age}) can produce {this.ProductPerDay} eggs per day.";
    }
}