using UnityEngine;

namespace Project.Weapons
{
    [AddComponentMenu("Project/Weapons/Projectile")]
    [DisallowMultipleComponent]
    public class Projectile : MonoBehaviour, IProjectile
    {
        public Rigidbody2D Rigidbody = null;

        public virtual ProjectileSO ProjectileData { get; set; }
        public ProjectilePoolSO Pool { get; set; }

        public virtual void Spawn(Vector3 position, Vector2 direction)
        {
            gameObject.SetActive(true);
            transform.position = position;
            float angle = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);
            transform.eulerAngles = new Vector3(0, 0, angle);
            if (Rigidbody) Rigidbody.velocity = ProjectileData.Speed * direction;
        }

        public void ReturnToPool()
        {
            gameObject.SetActive(false);
            Pool.Return(this);
        }
    }
}
