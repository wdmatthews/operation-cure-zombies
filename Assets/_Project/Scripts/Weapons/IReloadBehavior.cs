namespace Project.Weapons
{
    public interface IReloadBehavior
    {
        void StartReload(IWeapon weapon);
        void CancelReload(IWeapon weapon);
        void FinishReload(IWeapon weapon);
        void OnUpdate(IWeapon weapon);
    }
}
