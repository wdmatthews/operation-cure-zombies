using UnityEngine;

namespace Project.Combat
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        public DamageableSO DamageableData { get; set; }
        public float Health { get; set; }
        public bool IsDead => Mathf.Approximately(Health, 0);

        public void Heal(float amount)
        {
            Health = Mathf.Clamp(Health + amount, 0, DamageableData.MaxHealth);
        }

        public void TakeDamage(float amount)
        {
            Health = Mathf.Clamp(Health - amount, 0, DamageableData.MaxHealth);
        }
    }
}
