using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Project.Weapons;

namespace Project.Tests.PlayMode
{
    public class WeaponTests
    {
        public class Use
        {
            [UnityTest]
            public IEnumerator Given_HasNoAmmo_Then_CannotUse()
            {
                Weapon weapon = A.Weapon;
                Assert.IsFalse(weapon.CanUse);
                yield return null;
            }
        }
    }
}
