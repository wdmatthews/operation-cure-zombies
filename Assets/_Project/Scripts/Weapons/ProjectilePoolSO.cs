using UnityEngine;
using Project.Pooling;

namespace Project.Weapons
{
    [CreateAssetMenu(fileName = "New Projectile Pool", menuName = "Project/Weapons/Projectile Pool")]
    public class ProjectilePoolSO : PoolSO<Projectile> { }
}
