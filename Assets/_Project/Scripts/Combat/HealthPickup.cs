using UnityEngine;
using Project.Pickups;

namespace Project.Combat
{
    public class HealthPickup : Pickup
    {
        public HealthPickupSO HealthPickupData { get => (HealthPickupSO)PickupData; set => PickupData = value; }

        public override void Apply(MonoBehaviour behavior)
        {
            Damageable damageable = (Damageable)behavior;
            if (Mathf.Approximately(damageable.Health, damageable.DamageableData.MaxHealth)) return;
            damageable.Heal(HealthPickupData.Value);
            ReturnToPool();
        }
    }
}
