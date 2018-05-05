public class Person
{
    private string name;
    private int age;

    public Person()
    {
        Name = "No name";
        Age = 1;
    }

    public Person(int age)
        : this()
    {
        Age = age;
    }

    public Person(int age, string name)
        : this(age)
    {
        Name = name;
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
}

