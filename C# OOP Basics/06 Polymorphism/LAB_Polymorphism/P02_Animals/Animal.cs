public class Animal
{
    public Animal() { }

    public Animal(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }

    public string Name { get; private set; }

    public string FavouriteFood { get; set; }

    public virtual string ExplainSelf()
    {
        return null;
    }
}