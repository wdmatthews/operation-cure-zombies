using UnityEngine;
using Project.Pickups;

namespace Project.Weapons
{
    [CreateAssetMenu(fileName = "New Weapon Pickup", menuName = "Project/Weapons/Weapon Pickup")]
    public class WeaponPickupSO : PickupSO
    {
        public WeaponSO WeaponData = null;
    }
}
