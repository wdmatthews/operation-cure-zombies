using UnityEngine;

namespace Project.Weapons
{
    [CreateAssetMenu(fileName = "Standard Reload Behavior", menuName = "Project/Weapons/Standard Reload Behavior")]
    public class StandardReloadBehaviorSO : ReloadBehaviorSO
    {
        public override void StartReload(IWeapon weapon) { }

        public override void CancelReload(IWeapon weapon) { }

        public override void FinishReload(IWeapon weapon)
        {
            int availableAmmo = weapon.AmmoInReserve;
            int neededAmmo = weapon.WeaponData.ClipSize - weapon.AmmoInClip;
            int amount = Mathf.Min(neededAmmo, availableAmmo);
            weapon.ChangeAmmoInClip(amount);
            weapon.ChangeAmmoInReserve(-amount);
        }

        public override void OnUpdate(IWeapon weapon) { }
    }
}
