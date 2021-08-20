using System.Collections.Generic;
using UnityEngine;

namespace Project.Weapons
{
    [CreateAssetMenu(fileName = "New Projectile", menuName = "Project/Weapons/Projectile")]
    public class ProjectileSO : ScriptableObject
    {
        public ProjectilePoolSO Pool = null;
        public float Speed = 1;

        public Projectile Request()
        {
            Projectile projectile = Pool.Request();
            projectile.Pool = Pool;
            return projectile;
        }

        public List<Projectile> Request(int amount)
        {
            List<Projectile> projectiles = Pool.Request(amount);

            for (int i = 0; i < amount; i++)
            {
                projectiles[i].Pool = Pool;
            }

            return projectiles;
        }
    }
}
