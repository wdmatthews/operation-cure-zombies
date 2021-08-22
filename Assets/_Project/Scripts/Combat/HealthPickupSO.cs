using UnityEngine;
using Project.Pickups;

namespace Project.Combat
{
    [CreateAssetMenu(fileName = "New Health Pickup", menuName = "Project/Combat/Health Pickup")]
    public class HealthPickupSO : PickupSO
    {
        public float Value = 1;
    }
}
