namespace Project.Tests
{
    public static class A
    {
        public static WeaponBuilder Weapon => new WeaponBuilder();
        public static ProjectileBuilder Projectile => new ProjectileBuilder();
        public static DamageableBuilder Damageable => new DamageableBuilder();
    }
}
