using UnityEngine.InputSystem;
using Project.Weapons;
using Project.Variables;

namespace Project.Characters
{
    public interface IPlayer
    {
        PlayerSO PlayerData { get; set; }
        SelectionList<Weapon> Weapons { get; set; }

        void Move(InputAction.CallbackContext context);
        void Aim(InputAction.CallbackContext context);
        void AddWeapon(Weapon weapon);
        void RemoveWeapon(int index);
        void SelectWeapon(int index);
        void SelectPreviousWeapon();
        void SelectNextWeapon();
        void SelectPreviousWeapon(InputAction.CallbackContext context);
        void SelectNextWeapon(InputAction.CallbackContext context);
    }
}
