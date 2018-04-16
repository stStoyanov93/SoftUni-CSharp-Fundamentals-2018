using System;
using System.Reflection;
using System.Linq;

using P05_P06_AttributesLab;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);

                foreach (SoftUniAttribute atr in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {atr.Name}");
                }
            }
        }
    }
}
