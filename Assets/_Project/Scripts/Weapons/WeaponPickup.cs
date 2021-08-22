using UnityEngine;
using Project.Pickups;

namespace Project.Weapons
{
    public class WeaponPickup : Pickup
    {
        public WeaponPickupSO WeaponPickupData { get => (WeaponPickupSO)PickupData; set => PickupData = value; }

        public override void Apply(MonoBehaviour behavior)
        {
            IWeaponHolder weaponHolder = (IWeaponHolder)behavior;
            Weapon weapon = WeaponPickupData.WeaponData.Request();
            weaponHolder.PickUpWeapon(weapon);
            ReturnToPool();
        }
    }
}
