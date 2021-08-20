using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using Project.Weapons;

namespace Project.Tests.PlayMode
{
    public class ProjectileTests
    {
        public class Pool
        {
            [UnityTest]
            public IEnumerator RequestProjectile()
            {
                ProjectileSO projectileData = ProjectileBuilder.DefaultData;
                Projectile projectile = projectileData.Request();
                Assert.AreNotEqual(projectile, null);
                Assert.AreNotEqual(projectile, projectileData.Pool.Prefab);
                yield return null;
            }

            [UnityTest]
            public IEnumerator ReturnProjectile()
            {
                ProjectileSO projectileData = ProjectileBuilder.DefaultData;
                Projectile projectile = projectileData.Request();
                Assert.IsTrue(projectileData.Pool.Items.Count == 0);
                projectile.ReturnToPool();
                Assert.IsTrue(projectileData.Pool.Items.Count == 1);
                yield return null;
            }
        }
    }
}
