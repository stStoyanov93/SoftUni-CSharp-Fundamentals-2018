using System;

public class Cat : Animal
{
    public Cat(string name, string favouriteFood)
        : base(name, favouriteFood) { }

    public override string ExplainSelf()
    {
        var result = $"I am {this.Name} and favourite food is {this.FavouriteFood}{Environment.NewLine}MEEOW";

        return result;
    }
}