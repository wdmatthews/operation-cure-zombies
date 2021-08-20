namespace Project.Weapons
{
    public interface IWeapon
    {
        WeaponSO Data { get; set; }
        int AmmoInClip { get; set; }
        int AmmoInReserve { get; set; }
        float CooldownTimer { get; set; }
        float ReloadTimer { get; set; }
        bool IsCoolingDown { get; set; }
        bool IsReloading { get; set; }
        bool IsDoneCoolingDown { get; }
        bool HasAmmo { get; }
        bool NeedsToReload { get; }
        bool CanUse { get; }

        void Use();
        void StartCooldown();
        void EndCooldown();
        void Reload();
        void OnUpdate();
    }
}
