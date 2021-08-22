using UnityEngine;
using Project.Pickups;

namespace Project.Weapons
{
    public class AmmoPickup : Pickup
    {
        public AmmoPickupSO AmmoPickupData { get => (AmmoPickupSO)PickupData; set => PickupData = value; }

        public override void Apply(MonoBehaviour behavior)
        {
            IWeaponHolder weaponHolder = (IWeaponHolder)behavior;
            AmmoPickupSO pickupData = AmmoPickupData;
            if (!weaponHolder.PickUpAmmo(pickupData.AmmoType, pickupData.Amount)) return;
            ReturnToPool();
        }
    }
}
