using UnityEngine;

namespace Project.Weapons
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        public virtual WeaponSO Data { get; set; }
        public int AmmoInClip { get; set; }
        public int AmmoInReserve { get; set; }
        public float CooldownTimer { get; set; }
        public float ReloadTimer { get; set; }
        public bool IsCoolingDown { get; set; }
        public bool IsReloading { get; set; }
        public bool IsDoneCoolingDown => IsCoolingDown && Mathf.Approximately(CooldownTimer, 0);
        public virtual bool HasAmmo => AmmoInClip > 0 || AmmoInReserve > 0;
        public virtual bool NeedsToReload => AmmoInClip == 0;
        public virtual bool CanUse => !IsCoolingDown && !IsReloading && HasAmmo;

        public virtual void Use()
        {
            if (!CanUse) return;

            if (NeedsToReload)
            {
                Reload();
                return;
            }

            StartCooldown();
        }

        public virtual void StartCooldown()
        {
            if (IsCoolingDown) return;
            IsCoolingDown = true;
            CooldownTimer = Data.CooldownDuration;
        }

        public virtual void EndCooldown()
        {
            if (!IsCoolingDown) return;
            IsCoolingDown = false;
        }

        public virtual void Reload()
        {
            if (IsReloading) return;
            IsReloading = true;
        }

        public virtual void OnUpdate()
        {
            if (IsDoneCoolingDown) EndCooldown();
            else if (IsCoolingDown) CooldownTimer = Mathf.Clamp(CooldownTimer - Time.deltaTime, 0, Data.CooldownDuration);
            if (IsReloading) Data.ReloadBehavior.OnUpdate(this);
        }
    }
}
