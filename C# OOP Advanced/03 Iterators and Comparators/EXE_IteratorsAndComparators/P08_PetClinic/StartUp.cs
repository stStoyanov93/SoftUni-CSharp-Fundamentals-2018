using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_PetClinic
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var pets = new List<Pet>();
            var clinics = new List<Clinic>();
            var input = string.Empty;
            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                input = Console.ReadLine();

                var inputParams = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = inputParams[0];
                inputParams.RemoveAt(0);

                switch (command)
                {
                    case "Create":

                        var type = inputParams[0];

                        if (type == "Pet")
                        {
                            var name = inputParams[1];
                            var age = int.Parse(inputParams[2]);
                            var kind = inputParams[3];
                            var pet = new Pet(name, age, kind);
                            pets.Add(pet);
                        }
                        else if (type == "Clinic")
                        {
                            var name = inputParams[1];
                            var roomCount = int.Parse(inputParams[2]);

                            try
                            {
                                var clinic = new Clinic(name, roomCount);
                                clinics.Add(clinic);
                            }
                            catch (InvalidOperationException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }

                        break;
                    case "Add":
                        Console.WriteLine(clinics.First(c => c.Name == inputParams[1]).Add(pets.First(p => p.Name == inputParams[0])));
                        break;
                    case "Release":
                        Console.WriteLine(clinics.First(c => c.Name == inputParams[0]).Release());
                        break;
                    case "HasEmptyRooms":
                        Console.WriteLine(clinics.First(c => c.Name == inputParams[0]).HasEmptyRooms());
                        break;
                    case "Print":
                        if (inputParams.Count == 1)
                        {
                            clinics.First(c => c.Name == inputParams[0]).Print();
                        }
                        else if (inputParams.Count > 1)
                        {
                            clinics.First(c => c.Name == inputParams[0]).Print(int.Parse(inputParams[1]));
                        }

                        break;
                    default:
                        throw new InvalidOperationException("Invalid Operation!");
                }
            }
        }
    }
}
