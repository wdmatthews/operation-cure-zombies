using UnityEngine;

namespace Project.Weapons
{
    public interface IProjectile
    {
        ProjectileSO ProjectileData { get; set; }
        ProjectilePoolSO Pool { get; set; }

        void Spawn(Vector3 position, Vector2 direction);
        void ReturnToPool();
    }
}
