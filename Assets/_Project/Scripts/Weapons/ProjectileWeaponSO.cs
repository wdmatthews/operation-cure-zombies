using UnityEngine;

namespace Project.Weapons
{
    [CreateAssetMenu(fileName = "New Projectile Weapon", menuName = "Project/Weapons/Projectile Weapon")]
    public class ProjectileWeaponSO : WeaponSO
    {
        [Space]
        [Header("Projectile")]
        public ProjectileSO Projectile = null;
    }
}
