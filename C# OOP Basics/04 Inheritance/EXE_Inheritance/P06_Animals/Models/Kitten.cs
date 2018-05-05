public class Kitten : Cat
{
    public Kitten(string name, int age, string gender = "Female") :
        base(name, age, "Female") {  }

    public override string ProduceSound()
    {
        return "Meow";
    }
}