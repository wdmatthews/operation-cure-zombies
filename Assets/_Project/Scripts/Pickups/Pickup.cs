using UnityEngine;

namespace Project.Pickups
{
    public abstract class Pickup : MonoBehaviour, IPickup
    {
        public PickupSO PickupData { get; set; }
        public PickupPoolSO Pool { get; set; }

        public abstract void Apply(MonoBehaviour behavior);
    }
}
