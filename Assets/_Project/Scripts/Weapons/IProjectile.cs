using UnityEngine;

namespace Project.Weapons
{
    public interface IProjectile
    {
        ProjectileSO Data { get; set; }
        ProjectilePoolSO Pool { get; set; }

        void Spawn(Vector3 position, Vector2 direction);
        void ReturnToPool();
    }
}
