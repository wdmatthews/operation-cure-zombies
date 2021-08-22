using UnityEngine;

namespace Project.Pickups
{
    public abstract class Pickup : MonoBehaviour, IPickup
    {
        public PickupSO PickupData { get; set; }
        public PickupPoolSO Pool { get; set; }

        public abstract void Apply(MonoBehaviour behavior);

        public virtual void Spawn(Vector3 position)
        {
            gameObject.SetActive(true);
            transform.position = position;
        }

        public void ReturnToPool()
        {
            gameObject.SetActive(false);
            Pool.Return(this);
        }
    }
}
