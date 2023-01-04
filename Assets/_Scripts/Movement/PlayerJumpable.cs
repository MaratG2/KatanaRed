using KatanaRed.Input;
using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.Movement
{
    public class PlayerJumpable : Jumpable
    {
        private MovementInput _movementInput;
        private JumpHitboxes _jumpHitboxes;
        public PlayerJumpable(JumpableData data, Rigidbody2D rb2d, MovementInput movementInput, JumpHitboxes jumpHitboxes) : base(data, rb2d)
        {
            this._movementInput = movementInput;
            this._jumpHitboxes = jumpHitboxes;
            _movementInput.OnJumpBegin += JumpBegin;
            _movementInput.OnJumpEnd += JumpEnd;
        }

        ~PlayerJumpable()
        {
            _movementInput.OnJumpBegin -= JumpBegin;
            _movementInput.OnJumpEnd -= JumpEnd;
        }

        public override void JumpBegin()
        {
            Debug.Log("Jump Begin");
        }

        public override void JumpEnd()
        {
            Debug.Log("Jump End");
        }
    }
}