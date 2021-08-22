using UnityEngine;
using Project.Pickups;
using Project.Weapons;

namespace Project.Tests
{
    public class AmmoPickupBuilder
    {
        private static AmmoPickupSO _defaultData = null;

        public static AmmoPickupSO DefaultData
        {
            get
            {
                if (_defaultData == null)
                {
                    _defaultData = ScriptableObject.CreateInstance<AmmoPickupSO>();
                    _defaultData.AmmoType = ScriptableObject.CreateInstance<AmmoTypeSO>();
                    _defaultData.Amount = 1;
                    _defaultData.Pool = ScriptableObject.CreateInstance<PickupPoolSO>();
                    _defaultData.Pool.Prefab = An.AmmoPickup;
                    _defaultData.Pool.Prefab.gameObject.SetActive(false);
                }

                return _defaultData;
            }
        }

        private AmmoPickupSO _data = null;

        public AmmoPickupBuilder WithData(AmmoPickupSO data)
        {
            _data = data;
            return this;
        }

        public AmmoPickup Build()
        {
            GameObject ammoPickupGO = new GameObject();
            AmmoPickup ammoPickup = ammoPickupGO.AddComponent<AmmoPickup>();
            ammoPickup.AmmoPickupData = _data;
            ammoPickup.Pool = _data ? _data.Pool : DefaultData.Pool;
            return ammoPickup;
        }

        public static implicit operator AmmoPickup(AmmoPickupBuilder builder) => builder.Build();
    }
}
