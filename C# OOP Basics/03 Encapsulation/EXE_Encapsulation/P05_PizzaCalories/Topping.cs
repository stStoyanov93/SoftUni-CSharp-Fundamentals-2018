using System;
using System.Linq;

public class Topping
{
    private string[] acceptedToppings = new string[] { "meat", "veggies", "cheese", "sauce" };

    private string type;
    private double weight;

    public Topping(string toppingType, double weight)
    {
        this.Type = toppingType;
        this.Weight = weight;
    }

    public string Type
    {
        get
        {
            return this.type;
        }
        private set
        {
            if (!acceptedToppings.Contains(value))
            {
                var fakeTopping = value[0].ToString().ToUpper() + value.Substring(1);
                throw new Exception($"Cannot place {fakeTopping} on top of your pizza.");
            }

            this.type = value;
        }
    }

    public double Weight
    {
        get
        {
            return this.weight;
        }
        private set
        {
            if (value < 1 || value > 50)
            {
                var valueName = this.type[0].ToString().ToUpper() + this.type.Substring(1);
                throw new Exception($"{valueName} weight should be in the range [1..50].");
            }

            this.weight = value;
        }
    }

    public double GetToppingCalories()
    {
        return 2 * Weight * GetToppingModifier();
    }

    private double GetToppingModifier()
    {
        if (this.Type == "meat")
        {
            return 1.2;
        }
        else if (this.Type == "veggies")
        {
            return 0.8;
        }
        else if (this.Type == "cheese")
        {
            return 1.1;
        }
        else
        {
            return 0.9;
        }
    }
}