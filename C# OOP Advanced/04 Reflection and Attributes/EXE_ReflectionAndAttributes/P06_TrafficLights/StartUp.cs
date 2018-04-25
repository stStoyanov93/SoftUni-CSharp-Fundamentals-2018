using System;
using System.Collections.Generic;

namespace P06_TrafficLights
{
    class StartUp
    {
        static void Main(string[] args)
        {          
            var inputLights = Console.ReadLine().Split();
            var trafficLights = new List<TrafficLight>();           

            foreach (var light in inputLights)
            {
                var initialLightColor = (LightColor)Enum.Parse(typeof(LightColor), light);
                trafficLights.Add(new TrafficLight(initialLightColor));
            }

            var switchesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < switchesCount; i++)
            {
                foreach (var light in trafficLights)
                {
                    light.ChangeColor();
                }

                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}
