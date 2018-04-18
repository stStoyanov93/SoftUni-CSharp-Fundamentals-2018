namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using _03BarracksFactory.Core.Commands;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var assembly = Assembly.GetCallingAssembly();
            var commandType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

            if (commandType == null)
            {
                throw new ArgumentException("Invalid Command!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandName} is not a command!");
            }

            var fieldsToInject = commandType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
                .ToArray();

            var fieldsParams = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

            var instanceParams = new object[] { data }.Concat(fieldsParams).ToArray();
            var instance = (IExecutable)Activator.CreateInstance(commandType, instanceParams);

            return instance;

           
        }
    }
}
