using UnityEngine;
using Project.Pooling;

namespace Project.Pickups
{
    [CreateAssetMenu(fileName = "New Pickup Pool", menuName = "Project/Pickups/Pickup Pool")]
    public class PickupPoolSO : PoolSO<Pickup> { }
}
