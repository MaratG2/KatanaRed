﻿using System.Threading.Tasks;
using KatanaRed.Input;
using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.Movement
{
    public class PlayerJumpable : Jumpable
    {
        private MovementInput _movementInput;
        private JumpHitboxes _jumpHitboxes;
        private bool _isJumpEnd;
        private float _oldMaxHeight = 0f;
        
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
                Jump(true);
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
            _isJumpEnd = true;
        }
        
        private void Jump(bool lowerRemaining)
        {
            if(lowerRemaining)
                _remainingJumps--;
            
            _isJumpEnd = false;
            JumpAsync();
        }

        private async Task JumpAsync()
        {
            float currentTime = 0f;
            float oldPositionY = rb2d.transform.position.y;
            float totalHeight = 0f;
            _oldMaxHeight = 0f;
            rb2d.gravityScale = data.jumpGravity;
            
            float jumpForce = Mathf.Sqrt(data.maxJumpHeight * -2 * (Physics2D.gravity.y * rb2d.gravityScale));
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            do
            {
                totalHeight = rb2d.transform.position.y - oldPositionY;
                currentTime += Time.fixedDeltaTime;
                await Task.Delay((int)(Time.fixedDeltaTime * 1000));
            } while ((!_isJumpEnd || totalHeight < data.minJumpHeight) && rb2d.velocity.y > 0);
            rb2d.gravityScale = data.stopGravity;
            while (rb2d.velocity.y > Mathf.Epsilon)
            {
                await Task.Delay((int)(Time.fixedDeltaTime * 1000));
            }
            rb2d.gravityScale = data.fallGravity;
        }

        private void AirJump()
        {
            _remainingAirJumps--;
            Jump(false);
        }
        private void WallJump()
        {
            _remainingWallJumps--;
            Jump(false);
        }
        
        private bool CanJump()
        {
            return _remainingJumps >= 1 && _jumpHitboxes.IsOnGround;
        }
        private bool CanAirJump()
        {
            return _remainingAirJumps >= 1 && !_jumpHitboxes.IsOnGround && !_jumpHitboxes.IsOnWall;
        }
        private bool CanWallJump()
        {
            return _remainingWallJumps >= 1 && !_jumpHitboxes.IsOnGround &&  _jumpHitboxes.IsOnWall;
        }

        private void GroundLanded()
        {
            _isJumpEnd = true;
            _remainingJumps = data.maxDefaultJumps;
            _remainingAirJumps = data.maxAirJumps;
            _remainingWallJumps = data.maxWallJumps;
        }
    }
}