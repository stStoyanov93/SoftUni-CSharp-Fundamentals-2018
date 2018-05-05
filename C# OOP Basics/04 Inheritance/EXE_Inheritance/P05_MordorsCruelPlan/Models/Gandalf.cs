using System;

public class Gandalf
{
    private int happinessIndex;
    private Mood mood;
    private MoodFactory moodFactory;

    public Gandalf()
    {
        this.moodFactory = new MoodFactory();
    }

    private void SetMood()
    {
        if (this.happinessIndex < -5)
        {
            this.mood = moodFactory.CreateMood("Angry");
        }
        else if (this.happinessIndex < 0)
        {
            this.mood = moodFactory.CreateMood("Sad");
        }
        else if (this.happinessIndex < 15)
        {
            this.mood = moodFactory.CreateMood("Happy");
        }
        else
        {
            this.mood = moodFactory.CreateMood("JavaScript");
        }
    }

    public void Eat(Food food)
    {
        this.happinessIndex += food.Happiness;
    }

    public override string ToString()
    {
        this.SetMood();

        var result = $"{this.happinessIndex}"
                        + Environment.NewLine
                        + $"{this.mood}";

        return result;
    }
}