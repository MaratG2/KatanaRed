using System.Threading.Tasks;
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
            JumpEndAsync();
            JumpAsync();
        }

        private async Task JumpEndAsync()
        {
            int totalTime = 0;
            while (!_isJumpEnd && totalTime < data.minMaxTime * 1000)
            {
                var waitTime = (int)(Time.fixedDeltaTime * 1000);
                totalTime += waitTime;
                await Task.Delay(waitTime);
            }
            JumpEnd();
        }

        private async Task JumpAsync()
        {
            float currentTime = 0f;
            float totalHeight = 0f;
            _oldMaxHeight = 0f;
            while (!_isJumpEnd || totalHeight < data.minJumpHeight)
            {
                currentTime += Time.fixedDeltaTime;
                float heightDelta = GetHeightDelta(currentTime);
                totalHeight += heightDelta;
                rb2d.velocity = new Vector2(rb2d.velocity.x, heightDelta / Time.fixedDeltaTime);
                await Task.Delay((int)(Time.fixedDeltaTime * 1000));
            }
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
        }

        private float GetHeightDelta(float currentTime)
        {
            float ratioTime = currentTime / data.minMaxTime;
            float heightDelta = data.jumpStrength.Evaluate(ratioTime) - _oldMaxHeight;
            _oldMaxHeight += heightDelta;
            return heightDelta;
        }
        
        private void AirJump()
        {
            _remainingJumps--;
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
            return _remainingJumps >= 1 && !_jumpHitboxes.IsOnGround && !_jumpHitboxes.IsOnWall;
        }
        private bool CanWallJump()
        {
            return !_jumpHitboxes.IsOnGround && _remainingWallJumps > 0 && _jumpHitboxes.IsOnWall;
        }

        private void GroundLanded()
        {
            _isJumpEnd = true;
            _remainingJumps = data.maxDefaultJumps;
            _remainingWallJumps = data.maxWallJumps;
        }
    }
}