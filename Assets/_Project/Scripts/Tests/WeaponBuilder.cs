using UnityEngine;
using Project.Weapons;

namespace Project.Tests
{
    public class WeaponBuilder
    {
        private static WeaponSO _defaultData = null;

        public static WeaponSO DefaultData
        {
            get
            {
                if (_defaultData == null)
                {
                    _defaultData = ScriptableObject.CreateInstance<WeaponSO>();
                    _defaultData.ClipSize = 2;
                    _defaultData.ReserveSize = 4;
                    _defaultData.CooldownDuration = 1;
                    _defaultData.ReloadDuration = 1;
                    _defaultData.ReloadBehavior = ScriptableObject.CreateInstance<StandardReloadBehaviorSO>();
                    _defaultData.Pool = ScriptableObject.CreateInstance<WeaponPoolSO>();
                    _defaultData.Pool.Prefab = A.Weapon;
                    _defaultData.Pool.Prefab.gameObject.SetActive(false);
                }

                return _defaultData;
            }
        }

        private WeaponSO _data = null;
        private int _ammoInClip = 0;
        private int _ammoInReserve = 0;

        public WeaponBuilder WithData(WeaponSO data)
        {
            _data = data;
            return this;
        }

        public WeaponBuilder WithAmmoInClip(int amount)
        {
            _ammoInClip = amount;
            return this;
        }

        public WeaponBuilder WithAmmoInReserve(int amount)
        {
            _ammoInReserve = amount;
            return this;
        }

        public Weapon Build()
        {
            GameObject weaponGO = new GameObject();
            Weapon weapon = weaponGO.AddComponent<Weapon>();
            weapon.WeaponData = _data;
            weapon.AmmoInClip = _ammoInClip;
            weapon.AmmoInReserve = _ammoInReserve;
            weapon.Pool = _data ? _data.Pool : DefaultData.Pool;
            return weapon;
        }

        public static implicit operator Weapon(WeaponBuilder builder) => builder.Build();
    }
}
