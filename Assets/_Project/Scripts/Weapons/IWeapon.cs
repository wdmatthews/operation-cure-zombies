namespace Project.Weapons
{
    public interface IWeapon
    {
        WeaponSO WeaponData { get; set; }
        int AmmoInClip { get; set; }
        int AmmoInReserve { get; set; }
        float CooldownTimer { get; set; }
        float ReloadTimer { get; set; }
        bool IsCoolingDown { get; set; }
        bool IsReloading { get; set; }
        bool IsDoneCoolingDown { get; }
        bool IsDoneReloading { get; }
        bool HasAmmo { get; }
        bool NeedsToReload { get; }
        bool CanUse { get; }
        bool CanReload { get; }

        void Use();
        void StartCooldown();
        void FinishCooldown();
        void StartReload();
        void CancelReload();
        void FinishReload();
        void ChangeAmmoInClip(int amount);
        void ChangeAmmoInReserve(int amount);
        void OnUpdate();
    }
}
