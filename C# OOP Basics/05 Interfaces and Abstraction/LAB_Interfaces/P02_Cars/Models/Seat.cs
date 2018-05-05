using System.Text;

public class Seat : ICar
{
    private string model;
    private string color;

    public Seat(string model, string color)
    {
        this.model = model;
        this.color = color;
    }

    public string Model => this.model;

    public string Color => this.color;

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

        sb.AppendLine($"{this.Color} {GetType().Name} {this.Model}")
          .AppendLine(this.Start())
          .AppendLine(this.Stop());

        return sb.ToString().TrimEnd();
    }
}