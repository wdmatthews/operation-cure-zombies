using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Project.Characters;
using Project.Combat;

namespace Project.Tests.PlayMode
{
    public class HealthPickupTests
    {
        public class PickUp
        {
            [UnityTest]
            public IEnumerator Given_HasLowHealth_Then_HasFullHealth()
            {
                PlayerSO playerData = PlayerBuilder.DefaultData;
                Player player = A.Player.WithData(playerData).WithHealth(1);
                HealthPickupSO pickupData = HealthPickupBuilder.DefaultData;
                HealthPickup pickup = A.HealthPickup.WithData(pickupData);
                pickup.Apply(player);
                Assert.IsTrue(Mathf.Approximately(player.Health, 2));
                yield return null;
            }
        }
    }
}
