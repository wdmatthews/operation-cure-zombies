using UnityEngine;
using Project.Pickups;
using Project.Weapons;

namespace Project.Tests
{
    public class WeaponPickupBuilder
    {
        private static WeaponPickupSO _defaultData = null;

        public static WeaponPickupSO DefaultData
        {
            get
            {
                if (_defaultData == null)
                {
                    _defaultData = ScriptableObject.CreateInstance<WeaponPickupSO>();
                    _defaultData.WeaponData = WeaponBuilder.DefaultData;
                    _defaultData.Pool = ScriptableObject.CreateInstance<PickupPoolSO>();
                    _defaultData.Pool.Prefab = A.WeaponPickup;
                    _defaultData.Pool.Prefab.gameObject.SetActive(false);
                    WeaponBuilder.DefaultData.WeaponPickup = _defaultData;
                }

                return _defaultData;
            }
        }

        private WeaponPickupSO _data = null;

        public WeaponPickupBuilder WithData(WeaponPickupSO data)
        {
            _data = data;
            return this;
        }

        public WeaponPickup Build()
        {
            GameObject weaponPickupGO = new GameObject();
            WeaponPickup weaponPickup = weaponPickupGO.AddComponent<WeaponPickup>();
            weaponPickup.WeaponPickupData = _data;
            weaponPickup.Pool = _data ? _data.Pool : DefaultData.Pool;
            return weaponPickup;
        }

        public static implicit operator WeaponPickup(WeaponPickupBuilder builder) => builder.Build();
    }
}
