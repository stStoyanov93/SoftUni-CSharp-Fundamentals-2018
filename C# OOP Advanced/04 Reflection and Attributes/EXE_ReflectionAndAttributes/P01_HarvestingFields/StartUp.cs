 namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main()
        {
            var classType = typeof(HarvestingFields);
            var fields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "HARVEST")
            {
                switch (input)
                {
                    case "private":
                        var privateFields = fields.Where(f => f.IsPrivate);
                        PrintFields(input, privateFields);
                        break;
                    case "protected":
                        var protectedFields = fields.Where(f => f.IsFamily);
                        PrintFields(input, protectedFields);
                        break;
                    case "public":
                        var publicFields = fields.Where(f => f.IsPublic);
                        PrintFields(input, publicFields);
                        break;
                    case "all":
                        PrintAllFields(fields);
                        break;
                }
            }

        }

        public static void PrintFields(string modifierType, IEnumerable<FieldInfo> fields)
        {
            foreach (var field in fields)
            {
                Console.WriteLine($"{modifierType} {field.FieldType.Name} {field.Name}");
            }
        }

        public static void PrintAllFields(IEnumerable<FieldInfo> fields)
        {
            foreach (var field in fields)
            {
                var acessModifier = field.Attributes.ToString().ToLower() == "family" ? "protected" : field.Attributes.ToString().ToLower();
                Console.WriteLine($"{acessModifier} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
