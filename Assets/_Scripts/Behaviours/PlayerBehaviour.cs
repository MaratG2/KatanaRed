using KatanaRed.Input;
using KatanaRed.Movement.Jump;
using KatanaRed.Movement.Run;
using KatanaRed.Utils.Scriptables;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Behaviours
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [Header("Dependencies")] 
        [SerializeField, Required] private Rigidbody2D _rb2d;
        [SerializeField, Required] private RunSO _movableData;
        [SerializeField, Required] private JumpSO _jumpSO;
        [SerializeField, Required] private WallJumpSO _wallJumpSO;
        [SerializeField, Required] private JumpHitboxes _jumpHitboxes;
        private MovementInput _movementInput;
        private Movable _movable;
        private Jumpable _jumpable;
        public Movable Movable => _movable;

        private void Awake()
        {
            _movementInput = GetComponent<MovementInput>();
            _movable = new PlayerMovable(_movableData, _rb2d);
            _jumpable = new PlayerJumpable(_jumpSO, _wallJumpSO, _rb2d, _movementInput, _jumpHitboxes);
            _movementInput.canMove = true;
        }

        private void FixedUpdate()
        {
            _movable.Move(_movementInput.Movement, Time.fixedDeltaTime, _movementInput.canMove);
        }
    }
}