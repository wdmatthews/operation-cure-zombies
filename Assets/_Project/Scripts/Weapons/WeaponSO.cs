using System.Collections.Generic;
using UnityEngine;

namespace Project.Weapons
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Project/Weapons/Weapon")]
    public class WeaponSO : ScriptableObject
    {
        public WeaponPoolSO Pool = null;
        public ScriptableObject WeaponPickup = null;

        [Header("Use")]
        public float CooldownDuration = 1;
        public bool IsAutomatic = false;

        [Space]
        [Header("Ammo")]
        public AmmoTypeSO AmmoType = null;
        public int ClipSize = 1;
        public int ReserveSize = 2;

        [Space]
        [Header("Reload")]
        public ReloadBehaviorSO ReloadBehavior = null;
        public float ReloadDuration = 1;

        public Weapon Request()
        {
            Weapon projectile = Pool.Request();
            projectile.WeaponData = this;
            projectile.Pool = Pool;
            return projectile;
        }

        public List<Weapon> Request(int amount)
        {
            List<Weapon> projectiles = Pool.Request(amount);

            for (int i = 0; i < amount; i++)
            {
                projectiles[i].WeaponData = this;
                projectiles[i].Pool = Pool;
            }

            return projectiles;
        }
    }
}
