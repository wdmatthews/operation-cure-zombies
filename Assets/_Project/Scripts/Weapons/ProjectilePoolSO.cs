using Project.Pooling;

namespace Project.Weapons
{
    public class ProjectilePoolSO : PoolSO<Projectile>
    {
        public Projectile Prefab = null;

        public override Projectile Create() => Instantiate(Prefab);
    }
}
