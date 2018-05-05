public abstract class Food
{
    private int happiness;

    protected Food(int happiness)
    {
        this.happiness = happiness;
    }

    public string Name => this.GetType().Name;

    public int Happiness => this.happiness;
}