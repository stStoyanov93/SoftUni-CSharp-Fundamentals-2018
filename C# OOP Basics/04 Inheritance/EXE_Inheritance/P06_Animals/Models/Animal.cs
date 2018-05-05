using System;

public abstract class Animal : ISoundProducable
{
    private const string INVALID_INPUT_MESSAGE = "Invalid input!";

    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        protected set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(INVALID_INPUT_MESSAGE);
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
        protected set
        {
            if (string.IsNullOrWhiteSpace(value.ToString()) || value < 0)
            {
                throw new ArgumentException(INVALID_INPUT_MESSAGE);
            }
            this.age = value;
        }
    }

    public string Gender
    {
        get
        {
            return this.gender;
        }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(INVALID_INPUT_MESSAGE);
            }

            this.gender = value;
        }
    }

    public abstract string ProduceSound();

    public override string ToString()
    {
        var result = $@"{this.GetType().Name}"
            + Environment.NewLine
            + $"{this.Name} {this.Age} {this.Gender}"
            + Environment.NewLine
            + $"{ProduceSound()}";

        return result;
    }
}