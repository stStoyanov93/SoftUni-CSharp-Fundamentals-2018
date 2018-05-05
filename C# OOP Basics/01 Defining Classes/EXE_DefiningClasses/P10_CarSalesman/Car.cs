using System.Text;

public class Car
{
    public Car (string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
    }

    public string Model { get; private set; }

    public Engine Engine { get; private set; }

    public string Weight { get; set; }

    public string Color { get; set; }

    public override string ToString()
    {
        var builder = new StringBuilder()
            .AppendLine($"{this.Model}:")
            .AppendLine($"  {this.Engine.Model}:")
            .AppendLine($"    Power: {this.Engine.Power}")
            .AppendLine($"    Displacement: {(this.Engine.Displacement) ?? "n/a"}")
            .AppendLine($"    Efficiency: {this.Engine.Efficiency ?? "n/a"}")
            .AppendLine($"  Weight: {this.Weight ?? "n/a"}")
            .AppendLine($"  Color: {this.Color ?? "n/a"}");

        return builder.ToString();
    }
}

