using UnityEngine;
using Project.Weapons;
using Project.Variables;

namespace Project.Characters
{
    public interface IPlayer
    {
        PlayerSO PlayerData { get; set; }
        SelectionList<Weapon> Weapons { get; set; }
        bool CanSwapWeapon { get; }

        void Move(Vector2 direction);
        void Aim(Vector2 direction);
        void AddWeapon(Weapon weapon, int index = -1);
        void RemoveWeapon(int index);
        void SelectWeapon(int index);
        void SelectPreviousWeapon();
        void SelectNextWeapon();
        void UseWeapon();
        void ReloadWeapon();
    }
}
