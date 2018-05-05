using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    var inputParams = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var command = inputParams[0];
                    var teamName = inputParams[1];
                    var playerName = string.Empty;

                    if (command == "Team")
                    {
                        var team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (command == "Add")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == teamName);

                        if (team == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        playerName = inputParams[2];

                        var endurance = int.Parse(inputParams[3]);
                        var sprint = int.Parse(inputParams[4]);
                        var dribble = int.Parse(inputParams[5]);
                        var passing = int.Parse(inputParams[6]);
                        var shooting = int.Parse(inputParams[7]);
                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        team.AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        playerName = inputParams[2];
                        var playerTeam = teams.FirstOrDefault(t => t.Name == teamName);
                        var playerToRemove = playerTeam.Players.FirstOrDefault(p => p.Name == playerName);

                        if (playerToRemove == null)
                        {
                            throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
                        }

                        playerTeam.RemovePlayer(playerToRemove);
                    }
                    else if (command == "Rating")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == teamName);

                        if (team == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        Console.WriteLine($"{teamName} - {team.GetRating()}");
                    }                       
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
            }
        }
    }
}
