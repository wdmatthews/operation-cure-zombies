using UnityEngine;
using Project.Pickups;

namespace Project.Weapons
{
    [CreateAssetMenu(fileName = "New Ammo Pickup", menuName = "Project/Weapons/Ammo Pickup")]
    public class AmmoPickupSO : PickupSO
    {
        public AmmoTypeSO AmmoType = null;
        public int Amount = 1;
    }
}
