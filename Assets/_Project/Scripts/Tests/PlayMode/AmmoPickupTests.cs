using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Project.Characters;
using Project.Weapons;

namespace Project.Tests.PlayMode
{
    public class AmmoPickupTests
    {
        public class PickUp
        {
            [UnityTest]
            public IEnumerator Given_HasNoAmmoAndOneValidWeaponAndOneInvalidWeapon_Then_HasAmmoInValidWeapon()
            {
                PlayerSO playerData = PlayerBuilder.DefaultData;
                AmmoPickupSO pickupData = AmmoPickupBuilder.DefaultData;
                WeaponSO[] weaponData = new WeaponSO[]
                {
                    ScriptableObject.CreateInstance<WeaponSO>(),
                    ScriptableObject.CreateInstance<WeaponSO>()
                };
                weaponData[1].AmmoType = pickupData.AmmoType;
                List<Weapon> weapons = new List<Weapon>
                {
                    A.Weapon.WithData(weaponData[0]),
                    A.Weapon.WithData(weaponData[1])
                };
                Player player = A.Player.WithData(playerData).WithWeapons(weapons);
                AmmoPickup pickup = An.AmmoPickup.WithData(pickupData);
                pickup.Apply(player);
                Assert.IsTrue(weapons[0].AmmoInReserve == 0);
                Assert.IsTrue(weapons[1].AmmoInReserve == 1);
                yield return null;
            }
        }
    }
}
