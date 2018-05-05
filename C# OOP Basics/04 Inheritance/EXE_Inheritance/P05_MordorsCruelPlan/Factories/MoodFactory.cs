using System;
using System.Linq;
using System.Reflection;

public class MoodFactory
{
    public Mood CreateMood(string type)
    {
        var typefMood = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

        var product = (Mood)Activator.CreateInstance(typefMood);
        return product;
    }
}