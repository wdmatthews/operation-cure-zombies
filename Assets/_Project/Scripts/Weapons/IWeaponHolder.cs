namespace Project.Weapons
{
    public interface IWeaponHolder
    {
        void PickUpWeapon(Weapon weapon);
        void DropWeapon(int index);
        bool PickUpAmmo(AmmoTypeSO ammoType, int amount);
    }
}
