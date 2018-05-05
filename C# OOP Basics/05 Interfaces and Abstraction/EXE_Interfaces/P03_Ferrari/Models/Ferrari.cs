public class Ferrari : ICar
{
    public Ferrari(string driverName)
    {
        this.Model = "488-Spider";
        this.Driver = driverName;
    }

    public string Model { get; private set; }

    public string Driver { get; private set; }

    public string PushGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.UseBrakes()}/{this.PushGasPedal()}/{this.Driver}";
    }
}