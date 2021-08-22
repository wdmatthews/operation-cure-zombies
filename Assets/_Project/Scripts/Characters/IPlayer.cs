using UnityEngine.InputSystem;
using Project.Weapons;
using Project.Variables;

namespace Project.Characters
{
    public interface IPlayer
    {
        SelectionList<Weapon> Weapons { get; set; }

        void Move(InputAction.CallbackContext context);
        void Aim(InputAction.CallbackContext context);
        void SelectWeapon(int index);
        void SelectPreviousWeapon();
        void SelectNextWeapon();
    }
}
