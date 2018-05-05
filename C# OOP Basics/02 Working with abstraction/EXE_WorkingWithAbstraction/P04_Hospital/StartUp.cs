using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var doctorsList = new Dictionary<string, List<string>>();
            var departments = new Dictionary<string, List<List<string>>>();

            FillHospital(doctorsList, departments);
            PrintPatients(doctorsList, departments);
        }

        private static void PrintPatients(Dictionary<string, List<string>> doctorsList, Dictionary<string, List<List<string>>> departments)
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var inputParams = input.Split();

                if (inputParams.Length == 1)
                {
                    Console.WriteLine(string.Join("\n",
                        departments[inputParams[0]]
                        .Where(x => x.Count > 0)
                        .SelectMany(x => x)));
                }
                else if (inputParams.Length == 2 && int.TryParse(inputParams[1], out int room))
                {
                    Console.WriteLine(string.Join("\n",
                        departments[inputParams[0]][room - 1]
                        .OrderBy(x => x)));
                }
                else
                {
                    string doctorName = inputParams[0] + " " + inputParams[1];
                    Console.WriteLine(string.Join("\n", doctorsList[doctorName].OrderBy(x => x)));
                }
            }
        }

        private static void FillHospital(Dictionary<string, List<string>> doctorsList, Dictionary<string, List<List<string>>> departments)
        {
            string input;

            while ((input = Console.ReadLine()) != "Output")
            {
                var inputParams = input.Split();

                var departament = inputParams[0];
                var doctorName = inputParams[1] + " " + inputParams[2];
                var patientName = inputParams[3];               

                if (!doctorsList.ContainsKey(doctorName))
                {
                    doctorsList[doctorName] = new List<string>();
                }

                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();

                    for (int room = 0; room < 20; room++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool isNotFull = departments[departament].SelectMany(x => x).Count() < 60;

                if (isNotFull)
                {
                    AddPatientsToRooms(doctorsList, departments, departament, doctorName, patientName);
                }
            }
        }

        private static void AddPatientsToRooms(Dictionary<string, List<string>> doctorsList, Dictionary<string, List<List<string>>> departments, string departament, string doctorName, string patientName)
        {
            var currentRoom = 0;
            doctorsList[doctorName].Add(patientName);

            for (int st = 0; st < departments[departament].Count; st++)
            {
                if (departments[departament][st].Count < 3)
                {
                    currentRoom = st;
                    break;
                }
            }

            departments[departament][currentRoom].Add(patientName);
        }
    }
}
