using Project.Weapons;
using Project.Variables;

namespace Project.Characters
{
    public interface IPlayer
    {
        SelectionList<Weapon> Weapons { get; set; }

        void SelectWeapon(int index);
        void SelectPreviousWeapon();
        void SelectNextWeapon();
    }
}
