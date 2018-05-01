using System;
using System.Linq;
using System.Reflection;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(string type, string name, Rarity rarity)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var model = assembly.GetTypes().FirstOrDefault(g => g.Name == type + "Weapon");

        if (model == null)
        {
            throw new ArgumentException($"Invalid weapon type!");
        }

        var isAssignable = typeof(IWeapon).IsAssignableFrom(model);

        if (!isAssignable)
        {
            throw new ArgumentException($"{type} is not a weapon type!");
        }

        return (IWeapon)Activator.CreateInstance(model, new object[] { name, rarity });
    }
}