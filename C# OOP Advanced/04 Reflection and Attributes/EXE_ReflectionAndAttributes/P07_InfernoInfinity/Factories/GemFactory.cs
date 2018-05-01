using System;
using System.Linq;
using System.Reflection;

public class GemFactory : IGemFactory
{
    public IGem CreateGem(string name, Clarity clarity)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var model = assembly.GetTypes().FirstOrDefault(g => g.Name == name + "Gem");

        if (model == null)
        {
            throw new ArgumentException($"Invalid gem type!");
        }

        var isAssignable = typeof(IGem).IsAssignableFrom(model);

        if (!isAssignable)
        {
            throw new ArgumentException($"{name} is not a gem type!");
        }

        return (IGem)Activator.CreateInstance(model, new object[] { name, clarity });
    }
}