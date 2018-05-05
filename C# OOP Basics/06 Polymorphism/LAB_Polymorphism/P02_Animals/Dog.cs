using System;

public class Dog : Animal
{
    public Dog(string name, string favouriteFood)
        : base(name, favouriteFood) { }

public override string ExplainSelf()
    {
        var result = $"I am {this.Name} and favourite food is {this.FavouriteFood}{Environment.NewLine}DJAAF";

        return result;
    }
}