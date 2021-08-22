using UnityEngine;

namespace Project.Pickups
{
    public interface IPickup
    {
        PickupSO PickupData { get; set; }
        PickupPoolSO Pool { get; set; }

        void Apply(MonoBehaviour behavior);
        void Spawn(Vector3 position);
        void ReturnToPool();
    }
}
