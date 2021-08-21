using UnityEngine;
using Project.Combat;
using Project.Variables;
using Project.Weapons;

namespace Project.Characters
{
    [AddComponentMenu("Project/Characters/Player")]
    [DisallowMultipleComponent]
    public class Player : Damageable, IPlayer
    {
        public SelectionList<Weapon> Weapons { get; set; } = new SelectionList<Weapon>();

        public void SelectWeapon(int index)
        {
            Weapons.Select(index);
        }

        public void SelectPreviousWeapon()
        {
            Weapons.SelectPrevious();
        }

        public void SelectNextWeapon()
        {
            Weapons.SelectNext();
        }
    }
}
