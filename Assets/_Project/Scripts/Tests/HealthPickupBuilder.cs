using UnityEngine;
using Project.Pickups;
using Project.Combat;

namespace Project.Tests
{
    public class HealthPickupBuilder
    {
        private static HealthPickupSO _defaultData = null;

        public static HealthPickupSO DefaultData
        {
            get
            {
                if (_defaultData == null)
                {
                    _defaultData = ScriptableObject.CreateInstance<HealthPickupSO>();
                    _defaultData.Value = 1;
                    _defaultData.Pool = ScriptableObject.CreateInstance<PickupPoolSO>();
                    _defaultData.Pool.Prefab = A.HealthPickup;
                    _defaultData.Pool.Prefab.gameObject.SetActive(false);
                }

                return _defaultData;
            }
        }

        private HealthPickupSO _data = null;

        public HealthPickupBuilder WithData(HealthPickupSO data)
        {
            _data = data;
            return this;
        }

        public HealthPickup Build()
        {
            GameObject healthPickupGO = new GameObject();
            HealthPickup healthPickup = healthPickupGO.AddComponent<HealthPickup>();
            healthPickup.HealthPickupData = _data;
            healthPickup.Pool = _data ? _data.Pool : DefaultData.Pool;
            return healthPickup;
        }

        public static implicit operator HealthPickup(HealthPickupBuilder builder) => builder.Build();
    }
}
