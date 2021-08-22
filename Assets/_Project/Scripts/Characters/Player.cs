using UnityEngine;
using UnityEngine.InputSystem;
using Project.Combat;
using Project.Variables;
using Project.Weapons;

namespace Project.Characters
{
    [AddComponentMenu("Project/Characters/Player")]
    [DisallowMultipleComponent]
    public class Player : Damageable, IPlayer
    {
        [SerializeField] private PlayerSO _initialPlayerData = null;
        [SerializeField] private WeaponSO[] _initialWeapons = { };
        [SerializeField] private Rigidbody2D _rigidbody = null;
        [SerializeField] private CameraVariableSO _camera = null;
        [SerializeField] private Transform _weaponContainer = null;

        public PlayerSO PlayerData { get => (PlayerSO)DamageableData; set => DamageableData = value; }
        public SelectionList<Weapon> Weapons { get; set; } = new SelectionList<Weapon>();

        private void Awake()
        {
            if (_initialPlayerData) PlayerData = _initialPlayerData;
            int initialWeaponCount = _initialWeapons.Length;

            for (int i = 0; i < initialWeaponCount; i++)
            {
                AddWeapon(_initialWeapons[i].Request());
            }

            if (initialWeaponCount > 0) SelectWeapon(0);
        }

        private void Update()
        {
            Weapons.Current?.OnUpdate();
        }

        public void Move(InputAction.CallbackContext context)
        {
            _rigidbody.velocity = PlayerData.MovementSpeed * context.ReadValue<Vector2>();
        }

        public void Aim(InputAction.CallbackContext context)
        {
            Vector2 direction = new Vector2();

            if (context.control.path == "/Mouse/delta")
            {
                Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
                Vector3 mouseWorldPosition = _camera.Value.ScreenToWorldPoint(mouseScreenPosition);
                direction = mouseWorldPosition - transform.position;
            }
            else direction = context.ReadValue<Vector2>();

            if (Mathf.Approximately(direction.x, 0) && Mathf.Approximately(direction.y, 0)) return;
            float angle = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }

        public void AddWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
            weapon.gameObject.SetActive(false);
            weapon.transform.SetParent(_weaponContainer, false);
        }

        public void RemoveWeapon(int index)
        {
            Weapons[index].transform.parent = null;
            Weapons.RemoveAt(index);
        }

        public void SelectWeapon(int index)
        {
            HideOldWeapon();
            Weapons.Select(index);
            ShowNewWeapon();
        }

        public void SelectPreviousWeapon()
        {
            HideOldWeapon();
            Weapons.SelectPrevious();
            ShowNewWeapon();
        }

        public void SelectNextWeapon()
        {
            HideOldWeapon();
            Weapons.SelectNext();
            ShowNewWeapon();
        }

        private void HideOldWeapon()
        {
            Weapons.Current?.gameObject.SetActive(false);
        }

        private void ShowNewWeapon()
        {
            Weapons.Current.gameObject.SetActive(true);
        }

        public void SelectPreviousWeapon(InputAction.CallbackContext context)
        {
            if (context.performed) SelectPreviousWeapon();
        }

        public void SelectNextWeapon(InputAction.CallbackContext context)
        {
            if (context.performed) SelectNextWeapon();
        }
    }
}
