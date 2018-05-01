using Microsoft.Extensions.DependencyInjection;
using System;

namespace P07_InfernoInfinity
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IWeaponRepository, WeaponRepository>();
            services.AddTransient<IWeaponFactory, WeaponFactory>();
            services.AddTransient<IGemFactory, GemFactory>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
