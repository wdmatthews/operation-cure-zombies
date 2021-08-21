using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Project.Combat;

namespace Project.Tests.PlayMode
{
    public class DamageableTests
    {
        public class Heal
        {
            [UnityTest]
            public IEnumerator Given_NoHealthAndFullyHeal_Then_FullyHeal()
            {
                DamageableSO damageableData = DamageableBuilder.DefaultData;
                Damageable damageable = A.Damageable.WithData(damageableData).WithHealth(0);
                damageable.Heal(2);
                Assert.IsTrue(damageable.Health == 2);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_NoHealthAndOverheal_Then_FullyHeal()
            {
                DamageableSO damageableData = DamageableBuilder.DefaultData;
                Damageable damageable = A.Damageable.WithData(damageableData).WithHealth(0);
                damageable.Heal(3);
                Assert.IsTrue(damageable.Health == 2);
                yield return null;
            }
        }

        public class TakeDamage
        {
            [UnityTest]
            public IEnumerator Given_FullHealthAndPartiallyDamage_Then_StillAlive()
            {
                DamageableSO damageableData = DamageableBuilder.DefaultData;
                Damageable damageable = A.Damageable.WithData(damageableData).WithHealth(2);
                damageable.TakeDamage(1);
                Assert.IsTrue(Mathf.Approximately(damageable.Health, 1));
                Assert.IsFalse(damageable.IsDead);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_FullHealthAndFullyDamage_Then_Dead()
            {
                DamageableSO damageableData = DamageableBuilder.DefaultData;
                Damageable damageable = A.Damageable.WithData(damageableData).WithHealth(2);
                damageable.TakeDamage(2);
                Assert.IsTrue(Mathf.Approximately(damageable.Health, 0));
                Assert.IsTrue(damageable.IsDead);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_FullHealthAndOverdamage_Then_Dead()
            {
                DamageableSO damageableData = DamageableBuilder.DefaultData;
                Damageable damageable = A.Damageable.WithData(damageableData).WithHealth(2);
                damageable.TakeDamage(3);
                Assert.IsTrue(Mathf.Approximately(damageable.Health, 0));
                Assert.IsTrue(damageable.IsDead);
                yield return null;
            }
        }
    }
}
