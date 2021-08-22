using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Project.Characters;
using Project.Weapons;

namespace Project.Tests.PlayMode
{
    public class WeaponPickupTests
    {
        public class PickUp
        {
            [UnityTest]
            public IEnumerator Given_HasNoWeapons_Then_HasWeapon()
            {
                PlayerSO playerData = PlayerBuilder.DefaultData;
                List<Weapon> weapons = new List<Weapon> { };
                Player player = A.Player.WithData(playerData).WithWeapons(weapons);
                WeaponPickupSO pickupData = WeaponPickupBuilder.DefaultData;
                WeaponPickup pickup = A.WeaponPickup.WithData(pickupData);
                pickup.Apply(player);
                Assert.IsTrue(player.Weapons.Count == 1);
                Assert.IsTrue(player.Weapons.CurrentIndex == 0);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_HasFullWeapons_Then_ReplacesSelectedWeapon()
            {
                PlayerSO playerData = PlayerBuilder.DefaultData;
                WeaponSO defaultWeaponData = WeaponBuilder.DefaultData;
                WeaponPickupSO pickupData = WeaponPickupBuilder.DefaultData;
                WeaponSO[] weaponData = new WeaponSO[]
                {
                    ScriptableObject.CreateInstance<WeaponSO>(),
                    ScriptableObject.CreateInstance<WeaponSO>(),
                    ScriptableObject.CreateInstance<WeaponSO>()
                };

                foreach (WeaponSO weaponSO in weaponData)
                {
                    weaponSO.Pool = defaultWeaponData.Pool;
                    weaponSO.WeaponPickup = defaultWeaponData.WeaponPickup;
                }

                List<Weapon> weapons = new List<Weapon>
                {
                    A.Weapon.WithData(weaponData[0]),
                    A.Weapon.WithData(weaponData[1]),
                    A.Weapon.WithData(weaponData[2])
                };
                Player player = A.Player.WithData(playerData).WithWeapons(weapons);
                WeaponPickup pickup = A.WeaponPickup.WithData(pickupData);
                pickup.Apply(player);
                Assert.IsTrue(player.Weapons.Count == 3);
                Assert.IsTrue(player.Weapons.CurrentIndex == 0);
                Assert.AreNotEqual(weapons[0], player.Weapons.Current);
                yield return null;
            }
        }

        public class Drop
        {
            [UnityTest]
            public IEnumerator Given_HasWeapon_Then_HasNoWeapon()
            {
                PlayerSO playerData = PlayerBuilder.DefaultData;
                List<Weapon> weapons = new List<Weapon> { A.Weapon.WithData(WeaponBuilder.DefaultData) };
                Player player = A.Player.WithData(playerData).WithWeapons(weapons);
                player.DropWeapon(0);
                Assert.IsTrue(player.Weapons.Count == 0);
                Assert.IsTrue(player.Weapons.CurrentIndex == -1);
                yield return null;
            }
        }
    }
}
