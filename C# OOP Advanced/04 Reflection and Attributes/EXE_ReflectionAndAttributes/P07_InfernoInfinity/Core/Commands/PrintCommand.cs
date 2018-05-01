using System;

public class PrintCommand : Command
{
    [Inject]
    private IWeaponRepository repository;

    public PrintCommand(string[] data, IWeaponRepository repository)
        : base(data)
    {
        this.repository = repository;
    }

    public override void Execute()
    {
        var weaponName = Data[1];
        var weapon = this.repository.GetWeapon(weaponName);

        if (weapon == null)
        {
            throw new ArgumentException($"Invalid Weapon!");
        }

        Console.WriteLine(weapon);
    }
}