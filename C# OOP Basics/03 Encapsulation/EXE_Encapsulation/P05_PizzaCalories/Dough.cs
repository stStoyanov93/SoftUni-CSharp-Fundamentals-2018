using System;
using System.Linq;

public class Dough
{
    private string[] acceptedFlourTypes = new string[] { "crispy", "chewy", "homemade" };
    private string[] acceptedDoughTypes = new string[] { "white", "wholegrain" };

    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get
        {
            return this.flourType;
        }
        private set
        {
            if (!acceptedDoughTypes.Contains(value))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;

        }
    }

    public string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }
        private set
        {
            if (!acceptedFlourTypes.Contains(value))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
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
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            this.weight = value;
        }
    }

    public double GetDoughCalories()
    {
        return (2 * this.Weight) * GetBakingModifier() * GetFlourModifier();
    }

    private double GetBakingModifier()
    {
        if (this.FlourType == "white")
        {
            return 1.5;
        };

        return 1.0;
    }

    private double GetFlourModifier()
    {
        if (this.BakingTechnique == "crispy")
        {
            return 0.9;
        }
        else if (this.BakingTechnique == "chewy")
        {
            return 1.1;
        }

        return 1.0;
    }
}