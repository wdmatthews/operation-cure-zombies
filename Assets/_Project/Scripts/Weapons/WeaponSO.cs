using UnityEngine;

namespace Project.Weapons
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Project/Weapons/Weapon")]
    public class WeaponSO : ScriptableObject
    {
        [Header("Use")]
        public float CooldownDuration = 1;

        [Space]
        [Header("Ammo")]
        public AmmoTypeSO AmmoType = null;
        public int ClipSize = 1;
        public int ReserveSize = 2;

        [Space]
        [Header("Reload")]
        public ReloadBehaviorSO ReloadBehavior = null;
        public float ReloadDuration = 1;
    }
}
