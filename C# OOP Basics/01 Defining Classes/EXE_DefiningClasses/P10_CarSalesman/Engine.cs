public class Engine
{
    public Engine(string model, string power)
    {
        this.Model = model;
        this.Power = power;
    }

    public string Model { get; private set; }

    public string Power { get; private set; }

    public string Displacement { get; set; }

    public string Efficiency { get; set; }
}

