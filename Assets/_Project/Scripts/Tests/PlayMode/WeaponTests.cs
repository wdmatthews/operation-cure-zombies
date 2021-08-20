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
                Weapon weapon = A.Weapon.WithAmmoInClip(0).WithAmmoInReserve(0);
                Assert.IsFalse(weapon.CanUse);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_IsCoolingDown_Then_CannotUse()
            {
                Weapon weapon = A.Weapon;
                weapon.IsCoolingDown = true;
                Assert.IsFalse(weapon.CanUse);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_IsReloading_Then_CannotUse()
            {
                Weapon weapon = A.Weapon;
                weapon.IsReloading = true;
                Assert.IsFalse(weapon.CanUse);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_HasAmmoInClip_Then_StartsCoolingDown()
            {
                WeaponSO weaponData = WeaponBuilder.DefaultData;
                Weapon weapon = A.Weapon.WithData(weaponData).WithAmmoInClip(1);
                weapon.Use();
                Assert.IsTrue(weapon.IsCoolingDown);
                Assert.IsTrue(Mathf.Approximately(weapon.CooldownTimer, weaponData.CooldownDuration));
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_HasAmmoInReserve_Then_StartsReloading()
            {
                WeaponSO weaponData = WeaponBuilder.DefaultData;
                Weapon weapon = A.Weapon.WithData(weaponData).WithAmmoInReserve(1);
                weapon.Use();
                Assert.IsTrue(weapon.IsReloading);
                Assert.IsTrue(Mathf.Approximately(weapon.ReloadTimer, weaponData.ReloadDuration));
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_CanUseAndResetCooldownTimer_Then_FinishesCoolingDown()
            {
                WeaponSO weaponData = WeaponBuilder.DefaultData;
                Weapon weapon = A.Weapon.WithData(weaponData).WithAmmoInClip(1);
                weapon.Use();
                weapon.CooldownTimer = 0;
                weapon.OnUpdate();
                Assert.IsTrue(!weapon.IsCoolingDown);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_CanUseAndResetReloadTimer_Then_FinishesReloading()
            {
                WeaponSO weaponData = WeaponBuilder.DefaultData;
                Weapon weapon = A.Weapon.WithData(weaponData).WithAmmoInReserve(1);
                weapon.Use();
                weapon.ReloadTimer = 0;
                weapon.OnUpdate();
                Assert.IsTrue(!weapon.IsReloading);
                yield return null;
            }
        }

        public class Cooldown
        {
            [UnityTest]
            public IEnumerator Given_IsCoolingDownAndFinishCooldown_Then_NotCoolingDown()
            {
                Weapon weapon = A.Weapon;
                weapon.IsCoolingDown = true;
                weapon.FinishCooldown();
                Assert.IsFalse(weapon.IsCoolingDown);
                yield return null;
            }
        }

        public class Reload
        {
            [UnityTest]
            public IEnumerator Given_IsReloadingAndCancelReload_Then_NotReloading()
            {
                WeaponSO weaponData = WeaponBuilder.DefaultData;
                Weapon weapon = A.Weapon.WithData(weaponData);
                weapon.IsReloading = true;
                weapon.CancelReload();
                Assert.IsFalse(weapon.IsReloading);
                yield return null;
            }

            [UnityTest]
            public IEnumerator Given_IsReloadingAndFinishReload_Then_NotReloading()
            {
                WeaponSO weaponData = WeaponBuilder.DefaultData;
                Weapon weapon = A.Weapon.WithData(weaponData);
                weapon.IsReloading = true;
                weapon.FinishReload();
                Assert.IsFalse(weapon.IsReloading);
                yield return null;
            }
        }
    }
}
