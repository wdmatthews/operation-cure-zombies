namespace Project.Weapons
{
    public class NullReloadBehaviorSO : ReloadBehaviorSO
    {
        public override void StartReload(IWeapon weapon) { }
        public override void CancelReload(IWeapon weapon) { }
        public override void FinishReload(IWeapon weapon) { }
        public override void OnUpdate(IWeapon weapon) { }
    }
}
