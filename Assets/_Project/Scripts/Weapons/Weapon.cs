using UnityEngine;

namespace Project.Weapons
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        public virtual WeaponSO WeaponData { get; set; }
        public WeaponPoolSO Pool { get; set; }
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
        public virtual bool CanReload => !IsReloading && AmmoInClip < WeaponData.ClipSize && AmmoInReserve > 0;

        public void ReturnToPool()
        {
            gameObject.SetActive(false);
            Pool.Return(this);
        }

        public virtual bool Use()
        {
            if (!CanUse) return false;

            if (NeedsToReload)
            {
                StartReload();
                return false;
            }

            StartCooldown();
            return true;
        }

        public virtual void StartCooldown()
        {
            if (IsCoolingDown) return;
            IsCoolingDown = true;
            CooldownTimer = WeaponData.CooldownDuration;
        }

        public virtual void ResetCooldown()
        {
            if (!IsCoolingDown) return;
            CooldownTimer = WeaponData.CooldownDuration;
        }

        public virtual void FinishCooldown()
        {
            if (!IsCoolingDown) return;
            IsCoolingDown = false;
        }

        public virtual void StartReload()
        {
            if (!CanReload) return;
            IsReloading = true;
            ReloadTimer = WeaponData.ReloadDuration;
            WeaponData.ReloadBehavior.StartReload(this);
        }

        public virtual void CancelReload()
        {
            if (!IsReloading) return;
            IsReloading = false;
            WeaponData.ReloadBehavior.CancelReload(this);
        }

        public virtual void FinishReload()
        {
            if (!IsReloading) return;
            IsReloading = false;
            WeaponData.ReloadBehavior.FinishReload(this);
        }

        public virtual void ChangeAmmoInClip(int amount)
        {
            AmmoInClip = Mathf.Clamp(AmmoInClip + amount, 0, WeaponData.ClipSize);
        }

        public virtual void ChangeAmmoInReserve(int amount)
        {
            AmmoInReserve = Mathf.Clamp(AmmoInReserve + amount, 0, WeaponData.ReserveSize);
        }

        public virtual void OnUpdate()
        {
            if (IsDoneCoolingDown) FinishCooldown();
            else if (IsCoolingDown) CooldownTimer = Mathf.Clamp(CooldownTimer - Time.deltaTime, 0, WeaponData.CooldownDuration);

            if (IsDoneReloading) FinishReload();
            else if (IsReloading)
            {
                ReloadTimer = Mathf.Clamp(ReloadTimer - Time.deltaTime, 0, WeaponData.ReloadDuration);
                WeaponData.ReloadBehavior.OnUpdate(this);
            }
        }
    }
}
