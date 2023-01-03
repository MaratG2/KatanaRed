using KatanaRed.Input;
using KatanaRed.Movement;
using KatanaRed.Scriptables;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Behaviours
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [Header("Dependencies")] 
        [SerializeField, Required] private Rigidbody2D _rb2d;
        [SerializeField, Required] private MovableData _movableData;
        [SerializeField, Required] private JumpableData _jumpableData;
        private MovementInput _movementInput;
        private Movable _movable;
        private Jumpable _jumpable;
        public Movable Movable => _movable;

        private void Awake()
        {
            _movementInput = GetComponent<MovementInput>();
            _movable = new PlayerMovable(_movableData, _rb2d);
            _jumpable = new PlayerJumpable(_jumpableData, _rb2d);
        }

        private void FixedUpdate()
        {
            _movable.Move(_movementInput.Movement, Time.fixedDeltaTime);
        }
    }
}