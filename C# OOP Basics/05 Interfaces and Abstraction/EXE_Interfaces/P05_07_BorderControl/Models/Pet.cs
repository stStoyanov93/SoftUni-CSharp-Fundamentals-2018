using System;

public class Pet : IBirthdate
{
    public Pet(string name, DateTime birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }

    public string Name { get; }

    public DateTime Birthdate { get; }
}