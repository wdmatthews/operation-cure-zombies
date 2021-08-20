using UnityEngine;

namespace Project.Weapons
{
    public abstract class ReloadBehaviorSO : ScriptableObject, IReloadBehavior
    {
        public abstract void StartReload(IWeapon weapon);
        public abstract void CancelReload(IWeapon weapon);
        public abstract void FinishReload(IWeapon weapon);
        public abstract void OnUpdate(IWeapon weapon);
    }
}
