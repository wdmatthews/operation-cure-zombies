using UnityEngine;
using Project.Combat;

namespace Project.Tests
{
    public class DamageableBuilder
    {
        private static DamageableSO _defaultData = null;

        public static DamageableSO DefaultData
        {
            get
            {
                if (_defaultData == null)
                {
                    _defaultData = ScriptableObject.CreateInstance<DamageableSO>();
                    _defaultData.MaxHealth = 2;
                }

                return _defaultData;
            }
        }

        private DamageableSO _data = null;
        private int _health = 0;

        public DamageableBuilder WithData(DamageableSO data)
        {
            _data = data;
            return this;
        }

        public DamageableBuilder WithHealth(int health)
        {
            _health = health;
            return this;
        }

        public Damageable Build()
        {
            GameObject damageableGO = new GameObject();
            Damageable damageable = damageableGO.AddComponent<Damageable>();
            damageable.DamageableData = _data;
            damageable.Health = _health;
            return damageable;
        }

        public static implicit operator Damageable(DamageableBuilder builder) => builder.Build();
    }
}
