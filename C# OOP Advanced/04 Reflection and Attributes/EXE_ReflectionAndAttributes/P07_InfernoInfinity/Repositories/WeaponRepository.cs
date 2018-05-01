using System.Collections.Generic;
using System.Linq;

public class WeaponRepository : IWeaponRepository
{
    private List<IWeapon> weapons;

    public WeaponRepository()
    {
        this.weapons = new List<IWeapon>();
    }

    public IList<IWeapon> Weapons => this.weapons.AsReadOnly();
  

    public void Add(IWeapon weapon)
    {
        this.weapons.Add(weapon);
    }

    public IWeapon GetWeapon(string weaponName)
    {
        return this.Weapons.FirstOrDefault(w => w.Name == weaponName);
    }
}