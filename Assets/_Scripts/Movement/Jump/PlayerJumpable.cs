using Cysharp.Threading.Tasks;
using KatanaRed.Input;
using KatanaRed.Utils.Scriptables;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Movement.Jump
{
    public class PlayerJumpable : Jumpable
    {
        [Header("Dependencies")]
        [SerializeField, Required] private MovementInput _movementInput;
        [SerializeField, Required] private GroundWallCollision _groundWallCollision;
        private bool _isJumpEnd;
        private float _oldMaxHeight = 0f;

        protected override void Awake()
        {
            base.Awake();
            _movementInput.OnJumpBegin += JumpBegin;
            _movementInput.OnJumpEnd += JumpEnd;
            _groundWallCollision.OnGroundLanded += GroundLanded;
        }

        ~PlayerJumpable()
        {
            _movementInput.OnJumpBegin -= JumpBegin;
            _movementInput.OnJumpEnd -= JumpEnd;
            _groundWallCollision.OnGroundLanded -= GroundLanded;
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
        private void AirJump()
        {
            _remainingAirJumps--;
            Jump(false);
        }
        private void WallJump()
        {
            _remainingWallJumps--;
            _isJumpEnd = false;
            WallJumpAsync();
        }

        private async UniTask JumpAsync()
        {
            rb2d.gravityScale = jumpData.JumpGravity;
            float jumpForce = Mathf.Sqrt(jumpData.MaxJumpHeight * -2 * (Physics2D.gravity.y * rb2d.gravityScale));
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            await WaitForJumpEnd();
            rb2d.gravityScale = jumpData.StopGravity;
            await WaitForJumpPeak();
            rb2d.gravityScale = jumpData.FallGravity;
        }
        
        private async UniTask WallJumpAsync()
        {
            _movementInput.canMove = false;
            rb2d.gravityScale = wallJumpData.JumpGravity;
            int direction = _groundWallCollision.IsOnLeft ? 1 : -1;
            float jumpForce = Mathf.Sqrt(wallJumpData.JumpForce * -2 * (Physics2D.gravity.y * rb2d.gravityScale));
            Vector2 force = jumpForce * wallJumpData.JumpPositiveDirection.normalized;
            force = new Vector2(force.x * direction, force.y);
            rb2d.AddForce(force, ForceMode2D.Impulse);
            await UniTask.Delay((int)(wallJumpData.JumpTime * 1000));
            rb2d.gravityScale = wallJumpData.StopGravity;
            _movementInput.canMove = true;
            await WaitForJumpPeak();
            rb2d.gravityScale = wallJumpData.FallGravity;
            await UniTask.Delay((int)(wallJumpData.FallTime * 1000));
        }

        private async UniTask WaitForJumpEnd()
        {
            float oldPositionY = rb2d.transform.position.y;
            float totalHeight;
            do
            {
                totalHeight = rb2d.transform.position.y - oldPositionY;
                await UniTask.WaitForFixedUpdate();
            } while ((!_isJumpEnd || totalHeight < jumpData.MinJumpHeight) && rb2d.velocity.y > 0);
        }
        private async UniTask WaitForJumpPeak()
        {
            while (rb2d.velocity.y > Mathf.Epsilon)
                await UniTask.WaitForFixedUpdate();
        }

        private bool CanJump()
        {
            return _remainingJumps >= 1 && _groundWallCollision.IsOnGround;
        }
        private bool CanAirJump()
        {
            return _remainingAirJumps >= 1 && !_groundWallCollision.IsOnGround && !_groundWallCollision.IsOnWall;
        }
        private bool CanWallJump()
        {
            return _remainingWallJumps >= 1 && !_groundWallCollision.IsOnGround &&  _groundWallCollision.IsOnWall;
        }

        private void GroundLanded()
        {
            _isJumpEnd = true;
            _remainingJumps = jumpData.MaxJumps;
            _remainingAirJumps = jumpData.MaxAirJumps;
            _remainingWallJumps = wallJumpData.MaxJumps;
        }
    }
}