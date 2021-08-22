using System.Collections.Generic;
using UnityEngine;
using Project.Characters;
using Project.Weapons;

namespace Project.Tests
{
    public class PlayerBuilder
    {
        private static PlayerSO _defaultData = null;

        public static PlayerSO DefaultData
        {
            get
            {
                if (_defaultData == null)
                {
                    _defaultData = ScriptableObject.CreateInstance<PlayerSO>();
                    _defaultData.MaxHealth = 2;
                    _defaultData.MaxWeaponCount = 3;
                }

                return _defaultData;
            }
        }

        private PlayerSO _data = null;
        private int _health = 0;
        private List<Weapon> _weapons = new List<Weapon>();
        private int _currentWeaponIndex = 0;

        public PlayerBuilder WithData(PlayerSO data)
        {
            _data = data;
            return this;
        }

        public PlayerBuilder WithHealth(int health)
        {
            _health = health;
            return this;
        }

        public PlayerBuilder WithWeapons(List<Weapon> weapons)
        {
            _weapons = weapons;
            return this;
        }

        public PlayerBuilder WithCurrentWeapon(int index)
        {
            _currentWeaponIndex = index;
            return this;
        }

        public Player Build()
        {
            GameObject playerGO = new GameObject();
            Player player = playerGO.AddComponent<Player>();
            player.DamageableData = _data;
            player.Health = _health;
            player.Weapons.AddRange(_weapons);
            player.Weapons.Select(_currentWeaponIndex);
            return player;
        }

        public static implicit operator Player(PlayerBuilder builder) => builder.Build();
    }
}
