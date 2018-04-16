using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
   public string StealFieldInfo (string className, params string[] requestedFields)
    {
        var classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields
            (BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        var classInstance = Activator.CreateInstance(classType, new object[] { });

        var builder = new StringBuilder();

        builder.AppendLine($"Class under investigation: {className}");

        foreach (var field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            builder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return builder.ToString().Trim();
    }

    public string AnalyzeAcessModifiers (string className)
    {
        var classType = Type.GetType(className);

        var fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        var publicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        var privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        var builder = new StringBuilder();

        foreach (var field in fields)
        {
            builder.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in privateMethods.Where(m => m.Name.StartsWith("get")))
        {
            builder.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            builder.AppendLine($"{method.Name} have to be private!");
        }

        return builder.ToString().Trim();
    }

    public string RevealPrivateMethods (string className)
    {
        var classType = Type.GetType(className);

        var baseClassName = classType.BaseType.Name;
        var privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var builder = new StringBuilder();

        builder.AppendLine($"All Private Methods of Class: {className}");
        builder.AppendLine($"Base Class: {baseClassName}");

        foreach (var method in privateMethods)
        {
            builder.AppendLine(method.Name);
        }

        return builder.ToString().Trim();
    }

    public string CollectGettersAndSetters (string className)
    {
        var classType = Type.GetType(className);

        var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        var builder = new StringBuilder();

        foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
        {
            builder.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
        {
            builder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return builder.ToString().Trim();
    }
}
