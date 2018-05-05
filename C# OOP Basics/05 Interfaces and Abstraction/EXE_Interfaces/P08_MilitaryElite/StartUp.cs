using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var inputParams = input.Split();
                var soldierType = inputParams[0];
                var id = int.Parse(inputParams[1]);
                var firstName = inputParams[2];
                var lastName = inputParams[3];

                switch (soldierType)
                {
                    case "Private":
                        var salary = double.Parse(inputParams[4]);
                        var soldierPrivate = new Private(id, firstName, lastName, salary);
                        soldiers.Add(soldierPrivate);
                        break;

                    case "Spy":
                        var codeNumber = int.Parse(inputParams[4]);
                        var spy = new Spy(id, firstName, lastName, codeNumber);
                        soldiers.Add(spy);
                        break;

                    case "LeutenantGeneral":
                        var generalSalary = double.Parse(inputParams[4]);
                        var inputSoldiers = inputParams.Skip(5).ToList();
                        var privates = GetCommandedPrivates(inputSoldiers, soldiers);

                        var general = new LeutenantGeneral(id, firstName, lastName, generalSalary, privates);
                        soldiers.Add(general);
                        break;

                    case "Commando":
                        if (!(inputParams[5] == "Marines" || inputParams[5] == "Airforces"))
                        {
                            break;
                        }

                        var commandoSalary = double.Parse(inputParams[4]);
                        var commandoCorps = inputParams[5];
                        var missions = GetValidMissions(inputParams.Skip(6).ToList());
                        var commando = new Commando(id, firstName, lastName, commandoSalary, commandoCorps, missions);
                        soldiers.Add(commando);
                        break;

                    case "Engineer":
                        if (!(inputParams[5] == "Marines" || inputParams[5] == "Airforces"))
                        {
                            break;
                        }
                        var eSalary = double.Parse(inputParams[4]);
                        var eCorps = inputParams[5];
                        var parts = GetRepairs(inputParams.Skip(6).ToList());
                        var engineer = new Engineer(id, firstName, lastName, eSalary, eCorps, parts);
                        soldiers.Add(new Engineer(int.Parse(inputParams[1]), inputParams[2], inputParams[3], double.Parse(inputParams[4]), inputParams[5], parts));
                        break;
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static IList<IPrivate> GetCommandedPrivates(IList<string> soldiers, IList<ISoldier> army)
        {
            var privatesList = new List<IPrivate>();

            foreach (var soldier in soldiers)
            {
                var soldierById = army.SingleOrDefault(s => s.Id == int.Parse(soldier));
                privatesList.Add((IPrivate)soldierById);
            }

            return privatesList;
        }

        private static IList<IMission> GetValidMissions(IList<string> missions)
        {
            var missionsList = new List<IMission>();

            for (int i = 0; i < missions.Count - 1; i += 2)
            {
                if (missions[i + 1] != "inProgress" && missions[i + 1] != "Finished")
                {
                    continue;
                }
                missionsList.Add(new Mission(missions[i], missions[i + 1]));
            }

            return missionsList;
        }

        private static IList<IRepair> GetRepairs(IList<string> parts)
        {
            var repairsList = new List<IRepair>();

            for (int i = 0; i < parts.Count - 1; i += 2)
            {
                repairsList.Add(new Repair(parts[i], int.Parse(parts[i + 1])));
            }

            return repairsList;
        }
    }
}
