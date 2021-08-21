using UnityEngine;
using Project.Weapons;

namespace Project.Tests
{
    public class ProjectileBuilder
    {
        private static ProjectileSO _defaultData = null;

        public static ProjectileSO DefaultData
        {
            get
            {
                if (_defaultData == null)
                {
                    _defaultData = ScriptableObject.CreateInstance<ProjectileSO>();
                    _defaultData.Speed = 1;
                    _defaultData.Pool = ScriptableObject.CreateInstance<ProjectilePoolSO>();
                    _defaultData.Pool.Prefab = A.Projectile;
                    _defaultData.Pool.Prefab.gameObject.SetActive(false);
                }

                return _defaultData;
            }
        }

        private ProjectileSO _data = null;

        public ProjectileBuilder WithData(ProjectileSO data)
        {
            _data = data;
            return this;
        }

        public Projectile Build()
        {
            GameObject projectileGO = new GameObject();
            Projectile projectile = projectileGO.AddComponent<Projectile>();
            projectile.ProjectileData = _data;
            return projectile;
        }

        public static implicit operator Projectile(ProjectileBuilder builder) => builder.Build();
    }
}
