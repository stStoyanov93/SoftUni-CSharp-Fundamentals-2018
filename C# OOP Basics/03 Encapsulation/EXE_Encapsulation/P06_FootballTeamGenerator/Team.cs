using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    public IReadOnlyCollection<Player> Players => this.players.AsReadOnly();

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        this.players.Remove(player);
    }

    public int GetRating()
    {
        if (this.players.Any())
        {
            var result = this.players.Average(p => p.GetOverralSkill());

            return (int)Math.Round(result);
        }

        return 0;
    }
}