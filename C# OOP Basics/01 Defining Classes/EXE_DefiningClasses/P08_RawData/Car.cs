public class Car
{
    public Car (string model, Engine e, Cargo c, Tire[] t)
    {
        this.Model = model;
        this.Engine = e;
        this.Cargo = c;
        this.Tires = t;
    }

    public string Model { get; set; }

    public Engine Engine { get; set; }

    public Cargo Cargo { get; set; }

    public Tire[] Tires { get; set; }
}

