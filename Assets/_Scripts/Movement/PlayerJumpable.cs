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
            _isJumpEnd = true;
            Debug.Log("Jump End");
        }
        
        private void Jump()
        {
            _remainingJumps--;
            _isJumpEnd = false;
            JumpEndAsync();
            JumpAsync();
            Debug.Log("Jump");
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
            while (!_isJumpEnd)
            {
                Debug.Log("Jumping...");
                currentTime += Time.fixedDeltaTime;
                float maxJumpHeight = GetHeightFromDataCurve(currentTime);
                float magicLowerCoeffitient = 1.2f;
                rb2d.AddForce(new Vector2(0f, maxJumpHeight / currentTime / magicLowerCoeffitient - Physics2D.gravity.y), ForceMode2D.Force);
                await Task.Delay((int)(Time.fixedDeltaTime * 1000));
            }
        }

        private float GetHeightFromDataCurve(float currentTime)
        {
            float ratioTime = currentTime / data.minMaxTime;
            return data.jumpStrength.Evaluate(ratioTime);
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
            return _remainingJumps >= 1 && _jumpHitboxes.IsOnGround;
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
            _isJumpEnd = true;
            _remainingJumps = data.maxDefaultJumps;
            _remainingWallJumps = data.maxWallJumps;
        }
    }
}