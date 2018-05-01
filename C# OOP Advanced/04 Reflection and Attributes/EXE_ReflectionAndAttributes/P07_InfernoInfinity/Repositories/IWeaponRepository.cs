public interface IWeaponRepository
{
    void Add(IWeapon data);

    IWeapon GetWeapon(string weaponName);
}