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
            _jumpHitboxes.OnGroundLanded += GroundLanded;
        }

        ~PlayerJumpable()
        {
            _movementInput.OnJumpBegin -= JumpBegin;
            _movementInput.OnJumpEnd -= JumpEnd;
            _jumpHitboxes.OnGroundLanded -= GroundLanded;
        }

        public override void JumpBegin()
        {
            if(CanJump())
            {
                Jump();
                return;
            }
            if (CanAirJump())
            {
                AirJump();
                return;
            }
            if(CanWallJump())
            {
                WallJump();
            }
        }
        public override void JumpEnd()
        {
            Debug.Log("Jump End");
        }
        
        private void Jump()
        {
            _remainingJumps--;
            Debug.Log("Jump");
        }
        private void AirJump()
        {
            _remainingJumps--;
            Debug.Log("AirJump");
        }
        private void WallJump()
        {
            _remainingWallJumps--;
            Debug.Log("WallJump");
        }
        
        private bool CanJump()
        {
            return _remainingJumps == 1 && _jumpHitboxes.IsOnGround;
        }
        private bool CanAirJump()
        {
            return _remainingJumps > 1 && !_jumpHitboxes.IsOnGround && !_jumpHitboxes.IsOnWall;
        }
        private bool CanWallJump()
        {
            return !_jumpHitboxes.IsOnGround && _remainingWallJumps > 0 && _jumpHitboxes.IsOnWall;
        }

        private void GroundLanded()
        {
            _remainingJumps = data.maxDefaultJumps;
            _remainingWallJumps = data.maxWallJumps;
        }
    }
}