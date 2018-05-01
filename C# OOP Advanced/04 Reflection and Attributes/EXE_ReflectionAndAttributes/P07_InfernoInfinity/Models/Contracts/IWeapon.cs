public interface IWeapon : ICommonStats
{
    string Name { get; }

    int MinDamage { get; }

    int MaxDamage { get; }

    int NumberOfSockets { get; }

    void AddGem(int index, IGem gem);

    void RemoveGem(int index);
}