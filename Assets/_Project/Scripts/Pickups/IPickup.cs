using UnityEngine;

namespace Project.Pickups
{
    public interface IPickup
    {
        PickupSO PickupData { get; set; }
        PickupPoolSO Pool { get; set; }

        void Apply(MonoBehaviour behavior);
    }
}
