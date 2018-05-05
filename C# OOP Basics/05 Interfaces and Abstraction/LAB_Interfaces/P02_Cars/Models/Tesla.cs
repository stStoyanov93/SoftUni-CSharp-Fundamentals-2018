using System.Text;

public class Tesla : IElectricCar
{
    private string model;
    private string color;
    private int battery;

    public Tesla(string model, string color, int battery)
    {
        this.model = model;
        this.color = color;
        this.battery = battery;
    }

    public string Model => this.model;

    public string Color => this.color;

    public int Battery => this.battery;

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Color} {GetType().Name} {this.Model} with {this.Battery} Batteries")
          .AppendLine(this.Start())
          .AppendLine(this.Stop());

        return sb.ToString().TrimEnd();
    }
}