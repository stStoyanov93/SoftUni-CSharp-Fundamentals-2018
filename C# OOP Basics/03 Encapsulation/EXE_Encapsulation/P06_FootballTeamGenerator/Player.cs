using System;

public class Player
{
    private const int MIN_VALUE = 0;
    private const int MAX_VALUE = 100;

    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
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

    public int Endurance
    {
        get
        {
            return this.endurance;
        }
        private set
        {
            if (value < MIN_VALUE || value > MAX_VALUE)
            {
                throw new ArgumentException($"Endurance should be between {MIN_VALUE} and {MAX_VALUE}.");
            }

            this.endurance = value;
        }
    }

    public int Sprint
    {
        get
        {
            return this.sprint;
        }
        private set
        {
            if (value < MIN_VALUE || value > MAX_VALUE)
            {
                throw new ArgumentException($"Sprint should be between {MIN_VALUE} and {MAX_VALUE}.");
            }

            this.sprint = value;
        }
    }

    public int Dribble
    {
        get
        {
            return this.dribble;
        }
        private set
        {
            if (value < MIN_VALUE || value > MAX_VALUE)
            {
                throw new ArgumentException($"Dribble should be between {MIN_VALUE} and {MAX_VALUE}.");
            }

            this.dribble = value;
        }
    }

    public int Passing
    {
        get
        {
            return this.passing;
        }
        private set
        {
            if (value < MIN_VALUE || value > MAX_VALUE)
            {
                throw new ArgumentException($"Passing should be between {MIN_VALUE} and {MAX_VALUE}.");
            }

            this.passing = value;
        }
    }

    public int Shooting
    {
        get
        {
            return this.shooting;
        }
        private set
        {
            if (value < MIN_VALUE || value > MAX_VALUE)
            {
                throw new ArgumentException($"Shooting should be between {MIN_VALUE} and {MAX_VALUE}.");
            }

            this.shooting = value;
        }
    }

    public int GetOverralSkill()
    {
        var result = (int)Math.Round(
            (this.Endurance + this.Sprint + this.Dribble + this.Shooting + this.Passing) / 5.0);

        return result;
    }
}