namespace Project.Weapons
{
    public class ProjectileWeapon : Weapon
    {
        public virtual ProjectileWeaponSO ProjectileWeaponData
        {
            get => (ProjectileWeaponSO)WeaponData;
            set => WeaponData = value;
        }

        public override bool Use()
        {
            if (!base.Use()) return false;
            SpawnProjectiles();
            return true;
        }

        protected virtual void SpawnProjectiles()
        {
            Projectile projectile = ProjectileWeaponData.Projectile.Request();
            projectile.Spawn(transform.position, transform.right);
            ChangeAmmoInClip(-1);
        }
    }
}
