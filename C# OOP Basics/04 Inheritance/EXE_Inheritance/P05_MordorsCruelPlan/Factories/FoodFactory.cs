using System;
using System.Linq;
using System.Reflection;

public class FoodFactory
{
    public Food CreateFood(string type)
    {
        var typeOfProduct = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.ToLower() == type.ToLower());

        if (typeOfProduct == null)
        {
            return new Other();
        }

        var product = (Food)Activator.CreateInstance(typeOfProduct);
        return product;
    }
}