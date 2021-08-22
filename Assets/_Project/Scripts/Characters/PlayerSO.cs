using UnityEngine;
using Project.Combat;

namespace Project.Characters
{
    [CreateAssetMenu(fileName = "New Player", menuName = "Project/Characters/Player")]
    public class PlayerSO : DamageableSO
    {
        [Space]
        [Header("Movement")]
        public float MovementSpeed = 1;
    }
}
