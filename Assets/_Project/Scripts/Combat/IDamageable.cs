namespace Project.Combat
{
    public interface IDamageable
    {
        DamageableSO DamageableData { get; set; }
        float Health { get; set; }
        bool IsDead { get; }

        void Heal(float amount);
        void TakeDamage(float amount);
    }
}
