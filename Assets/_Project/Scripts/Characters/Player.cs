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
        [SerializeField] private Rigidbody2D _rigidbody = null;
        [SerializeField] private CameraVariableSO _camera = null;

        public PlayerSO PlayerData { get => (PlayerSO)DamageableData; set => DamageableData = value; }
        public SelectionList<Weapon> Weapons { get; set; } = new SelectionList<Weapon>();

        private void Awake()
        {
            if (_initialPlayerData) PlayerData = _initialPlayerData;
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
