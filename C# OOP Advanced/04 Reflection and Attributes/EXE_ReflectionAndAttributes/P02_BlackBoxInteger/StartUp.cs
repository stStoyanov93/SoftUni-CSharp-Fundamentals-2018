namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main()
        {
            var classType = typeof(BlackBoxInteger);
            var blackBoxInstance = Activator.CreateInstance(classType, true);

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var inputParams = input.Split("_");
                var methodName = inputParams[0];
                var value = int.Parse(inputParams[1]);

                classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(blackBoxInstance, new object[] { value });

                var innerValue = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(f => f.Name == "innerValue").First().GetValue(blackBoxInstance);

                Console.WriteLine(innerValue);
            }
        }
    }
}
