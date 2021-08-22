using UnityEngine;

namespace Project.Pickups
{
    public abstract class Pickup : MonoBehaviour, IPickup
    {
        [SerializeField] protected string _playerLayerName = "Player";

        public PickupSO PickupData { get; set; }
        public PickupPoolSO Pool { get; set; }

        protected int _playerLayer = 0;

        protected void Awake()
        {
            _playerLayer = LayerMask.NameToLayer(_playerLayerName);
        }

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

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _playerLayer)
            {
                collision.GetComponent<IPickupInteractor>().PickupInRange = this;
            }
        }
    }
}
