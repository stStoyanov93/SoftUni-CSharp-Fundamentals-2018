using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P05_07_BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //P05
            //var newcomers = new List<IIdentity>();
            //string input;

            //while ((input = Console.ReadLine()) != "End")
            //{
            //    var inputParams = input.Split();
            //    IIdentity currentNewcomer;

            //    if (inputParams.Length == 3)
            //    {
            //        currentNewcomer = new Citizen(inputParams[0], int.Parse(inputParams[1]), inputParams[2]);
            //    }
            //    else
            //    {
            //        currentNewcomer = new Robot(inputParams[0], inputParams[1]);
            //    }

            //    newcomers.Add(currentNewcomer);
            //}

            //var lastDigitsOfFakeIds = Console.ReadLine();

            //var newcomersToDetain = newcomers.Where(m => m.Id.EndsWith(lastDigitsOfFakeIds));

            //foreach (var member in newcomersToDetain)
            //{
            //    Console.WriteLine(member.Id);
            //}

            //P06
            //var membersWithBirthdays = new List<IBirthdate>();

            //string input;

            //while ((input = Console.ReadLine()) != "End")
            //{
            //    var inputParams = input.Split();
            //    IBirthdate currentMember;

            //    if (inputParams[0] == "Pet")
            //    {
            //        var name = inputParams[1];
            //        var birthdate = DateTime.ParseExact(inputParams[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //        currentMember = new Pet(name, birthdate);
            //        membersWithBirthdays.Add(currentMember);
            //    }
            //    else if (inputParams[0] == "Citizen")
            //    {
            //        var name = inputParams[1];
            //        var age = int.Parse(inputParams[2]);
            //        var id = inputParams[3];
            //        var birthdate = DateTime.ParseExact(inputParams[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //        currentMember = new Citizen(name, age, id, birthdate);
            //        membersWithBirthdays.Add(currentMember);
            //    }
            //}

            //var yearFilter = int.Parse(Console.ReadLine());

            //var filteredMembers = membersWithBirthdays
            //    .Where(x => x.Birthdate.Year == yearFilter).ToList();

            //foreach (var member in filteredMembers)
            //{
            //    var date = member.Birthdate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            //    Console.WriteLine(date);
            //}

            //P07
            var numberOfPeople = int.Parse(Console.ReadLine());
            var buyers = new List<IBuyer>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                var inputParams = Console.ReadLine().Split();
                IBuyer currentBuyer;

                if (inputParams.Length == 3)
                {
                    var rebelName = inputParams[0];
                    var rebelAge = int.Parse(inputParams[1]);
                    var group = inputParams[2];

                    currentBuyer = new Rebel(rebelName, rebelAge, group);
                    buyers.Add(currentBuyer);
                }
                else if (inputParams.Length == 4)
                {
                    var citizenName = inputParams[0];
                    var citizenAge = int.Parse(inputParams[1]);
                    var id = inputParams[2];
                    var birdthday = DateTime.ParseExact(inputParams[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    currentBuyer = new Citizen(citizenName, citizenAge, id, birdthday);
                    buyers.Add(currentBuyer);
                }
            }

            string buyerName;

            while ((buyerName = Console.ReadLine()) != "End")
            {
                var buyer = buyers.FirstOrDefault(b => b.Name == buyerName);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            var totalFoodPurchased = buyers.Sum(b => b.Food);
            Console.WriteLine(totalFoodPurchased);
        }
    }
}
