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
        public virtual bool IsDoneCoolingDown => IsCoolingDown && Mathf.Approximately(CooldownTimer, 0);
        public virtual bool IsDoneReloading => IsReloading && Mathf.Approximately(ReloadTimer, 0);
        public virtual bool HasAmmo => AmmoInClip > 0 || AmmoInReserve > 0;
        public virtual bool NeedsToReload => AmmoInClip == 0;
        public virtual bool CanUse => !IsCoolingDown && !IsReloading && HasAmmo;

        public virtual void Use()
        {
            if (!CanUse) return;

            if (NeedsToReload)
            {
                StartReload();
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

        public virtual void FinishCooldown()
        {
            if (!IsCoolingDown) return;
            IsCoolingDown = false;
        }

        public virtual void StartReload()
        {
            if (IsReloading) return;
            IsReloading = true;
            ReloadTimer = Data.ReloadDuration;
            Data.ReloadBehavior.StartReload(this);
        }

        public virtual void CancelReload()
        {
            if (!IsReloading) return;
            IsReloading = false;
            Data.ReloadBehavior.CancelReload(this);
        }

        public virtual void FinishReload()
        {
            if (!IsReloading) return;
            IsReloading = false;
            Data.ReloadBehavior.FinishReload(this);
        }

        public virtual void OnUpdate()
        {
            if (IsDoneCoolingDown) FinishCooldown();
            else if (IsCoolingDown) CooldownTimer = Mathf.Clamp(CooldownTimer - Time.deltaTime, 0, Data.CooldownDuration);

            if (IsDoneReloading) FinishReload();
            else if (IsReloading)
            {
                ReloadTimer = Mathf.Clamp(ReloadTimer - Time.deltaTime, 0, Data.ReloadDuration);
                Data.ReloadBehavior.OnUpdate(this);
            }
        }
    }
}
