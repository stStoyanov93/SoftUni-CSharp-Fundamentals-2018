using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private Dough pizzaDough;
    private readonly List<Topping> toppings;

    public Pizza()
    {
        this.toppings = new List<Topping>();
    }

    public Pizza(string name)
        : this()
    {
        this.Name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new Exception("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public Dough PizzaDough
    {
        get { return this.pizzaDough; }
        set { this.pizzaDough = value; }
    }

    public IReadOnlyCollection<Topping> Toppings => this.toppings.AsReadOnly();

    public void AddTopping(Topping topping)
    {
        if (this.toppings.Count >= 10)
        {
            throw new Exception("Number of toppings should be in range [0..10].");
        }

        this.toppings.Add(topping);
    }

    public double PizzaCalories()
    {
        var coloriesFromToppings = this.toppings
            .Select(c => c.GetToppingCalories())
            .Sum();

        var totalCalories = this.PizzaDough.GetDoughCalories() + coloriesFromToppings;

        return totalCalories;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.PizzaCalories():f2} Calories.";
    }
}