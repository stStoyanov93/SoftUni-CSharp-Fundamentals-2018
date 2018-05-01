public interface IWeaponFactory
{
    IWeapon CreateWeapon(string weaponType, string weaponName, Rarity rarity);
}