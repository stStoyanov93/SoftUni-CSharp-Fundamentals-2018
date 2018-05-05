using System;
using System.Text;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    protected SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public string Corps { get; private set; }

    public override string ToString()
    {
        var result = base.ToString()
            + Environment.NewLine
            + $"Corps: {this.Corps}";

        return result;
    }
}