using UnityEngine;
using Project.Weapons;

namespace Project.Tests
{
    public class WeaponBuilder
    {
        private WeaponSO _data = null;

        public WeaponBuilder WithData(WeaponSO data)
        {
            _data = data;
            return this;
        }

        public Weapon Build()
        {
            GameObject weaponGO = new GameObject();
            Weapon weapon = weaponGO.AddComponent<Weapon>();
            weapon.Data = _data;
            return weapon;
        }

        public static implicit operator Weapon(WeaponBuilder builder)
        {
            return builder.Build();
        }
    }
}
