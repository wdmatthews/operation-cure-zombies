namespace Project.Weapons
{
    public class ProjectileWeapon : Weapon
    {
        public virtual ProjectileWeaponSO ProjectileWeaponData
        {
            get => (ProjectileWeaponSO)WeaponData;
            set => WeaponData = value;
        }

        public override void Use()
        {
            base.Use();
            SpawnProjectiles();
        }

        protected virtual void SpawnProjectiles()
        {
            Projectile projectile = ProjectileWeaponData.Projectile.Request();
            projectile.Spawn(transform.position, transform.right);
        }
    }
}
