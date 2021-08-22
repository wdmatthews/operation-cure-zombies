using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools;
using Project.Characters;
using Project.Weapons;

namespace Project.Tests.PlayMode
{
    public class PlayerTests
    {
        public class CurrentWeapon
        {
            [UnityTest]
            public IEnumerator Given_ThreeWeaponsAndSelectSecond_Then_SecondIsCurrent()
            {
                PlayerSO playerData = PlayerBuilder.DefaultData;
                List<Weapon> weapons = new List<Weapon> { A.Weapon, A.Weapon, A.Weapon };
                Player player = A.Player.WithData(playerData).WithWeapons(weapons).WithCurrentWeapon(0);
                player.SelectWeapon(1);
                Assert.IsTrue(player.Weapons.CurrentIndex == 1);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_ThreeWeaponsAndSecondIsCurrentAndSelectPrevious_Then_FirstIsCurrent()
            {
                PlayerSO playerData = PlayerBuilder.DefaultData;
                List<Weapon> weapons = new List<Weapon> { A.Weapon, A.Weapon, A.Weapon };
                Player player = A.Player.WithData(playerData).WithWeapons(weapons).WithCurrentWeapon(1);
                player.SelectPreviousWeapon();
                Assert.IsTrue(player.Weapons.CurrentIndex == 0);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_ThreeWeaponsAndSecondIsCurrentAndSelectNext_Then_LastIsCurrent()
            {
                PlayerSO playerData = PlayerBuilder.DefaultData;
                List<Weapon> weapons = new List<Weapon> { A.Weapon, A.Weapon, A.Weapon };
                Player player = A.Player.WithData(playerData).WithWeapons(weapons).WithCurrentWeapon(1);
                player.SelectNextWeapon();
                Assert.IsTrue(player.Weapons.CurrentIndex == 2);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_ThreeWeaponsAndFirstIsCurrentAndSelectPrevious_Then_LastIsCurrent()
            {
                PlayerSO playerData = PlayerBuilder.DefaultData;
                List<Weapon> weapons = new List<Weapon> { A.Weapon, A.Weapon, A.Weapon };
                Player player = A.Player.WithData(playerData).WithWeapons(weapons).WithCurrentWeapon(0);
                player.SelectPreviousWeapon();
                Assert.IsTrue(player.Weapons.CurrentIndex == 2);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_ThreeWeaponsAndLastIsCurrentAndSelectNext_Then_FirstIsCurrent()
            {
                PlayerSO playerData = PlayerBuilder.DefaultData;
                List<Weapon> weapons = new List<Weapon> { A.Weapon, A.Weapon, A.Weapon };
                Player player = A.Player.WithData(playerData).WithWeapons(weapons).WithCurrentWeapon(2);
                player.SelectNextWeapon();
                Assert.IsTrue(player.Weapons.CurrentIndex == 0);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_TwoWeaponsAndFirstIsCurrentAndRemoveFirst_Then_SecondIsFirstAndCurrent()
            {
                PlayerSO playerData = PlayerBuilder.DefaultData;
                List<Weapon> weapons = new List<Weapon> { A.Weapon, A.Weapon };
                Player player = A.Player.WithData(playerData).WithWeapons(weapons).WithCurrentWeapon(0);
                player.Weapons.RemoveAt(0);
                Assert.IsTrue(player.Weapons.CurrentIndex == 0);
                Assert.AreEqual(weapons[1], player.Weapons.Current);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_TwoWeaponsAndFirstIsCurrentAndRemoveSecond_Then_FirstIsStillCurrent()
            {
                PlayerSO playerData = PlayerBuilder.DefaultData;
                List<Weapon> weapons = new List<Weapon> { A.Weapon, A.Weapon };
                Player player = A.Player.WithData(playerData).WithWeapons(weapons).WithCurrentWeapon(0);
                player.Weapons.RemoveAt(1);
                Assert.IsTrue(player.Weapons.CurrentIndex == 0);
                Assert.AreEqual(weapons[0], player.Weapons.Current);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_TwoWeaponsAndSecondIsCurrentAndRemoveSecond_Then_FirstIsCurrent()
            {
                PlayerSO playerData = PlayerBuilder.DefaultData;
                List<Weapon> weapons = new List<Weapon> { A.Weapon, A.Weapon };
                Player player = A.Player.WithData(playerData).WithWeapons(weapons).WithCurrentWeapon(1);
                player.Weapons.RemoveAt(1);
                Assert.IsTrue(player.Weapons.CurrentIndex == 0);
                Assert.AreEqual(weapons[0], player.Weapons.Current);
                yield return null;
            }
        }
    }
}
