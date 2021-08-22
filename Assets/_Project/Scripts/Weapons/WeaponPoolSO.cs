using UnityEngine;
using Project.Pooling;

namespace Project.Weapons
{
    [CreateAssetMenu(fileName = "New Weapon Pool", menuName = "Project/Weapons/Weapon Pool")]
    public class WeaponPoolSO : PoolSO<Weapon> { }
}
