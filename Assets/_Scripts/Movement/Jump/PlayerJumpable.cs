using System;
using Cysharp.Threading.Tasks;
using KatanaRed.Input;
using KatanaRed.States;
using KatanaRed.Utils.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Movement.Jump
{
    public class PlayerJumpable : Jumpable
    {
        [SerializeField, Required] private MovementInput _movementInput;
        [SerializeField, Required] private GroundWallCollision _groundWallCollision;
        [SerializeField, Required] private StatesContainer _statesContainer;
        private bool _isJumpEnd;
        
        private void OnEnable()
        {
            _movementInput.OnJumpBegin += JumpBegin;
            _movementInput.OnJumpEnd += JumpEnd;
            _groundWallCollision.OnGroundLanded += GroundLanded;
        }

        private void OnDisable()
        {
            _movementInput.OnJumpBegin -= JumpBegin;
            _movementInput.OnJumpEnd -= JumpEnd;
            _groundWallCollision.OnGroundLanded -= GroundLanded;
        }

        public override void JumpBegin()
        {
            if (!StateAbleJump())
                return;
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
            
            _statesContainer.PlayerMovementSM.SetStateTo(PlayerMovementStateEnum.Jump);
            _isJumpEnd = false;
            JumpAsync();
        }
        private void AirJump()
        {
            _remainingAirJumps--;
            _statesContainer.PlayerMovementSM.SetStateTo(PlayerMovementStateEnum.AirJump);
            Jump(false);
        }
        private void WallJump()
        {
            _remainingWallJumps--;
            _isJumpEnd = false;
            _statesContainer.PlayerMovementSM.SetStateTo(PlayerMovementStateEnum.WallJump);
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
            float progress = 0f;
            //ToSide
            DoWallJump(PlayerWallJumpStateEnum.ToSide, wallJumpData.TSJumpGravity,
                wallJumpData.TSJumpForce, wallJumpData.TSJumpDirection, false);
            await UniTask.Delay((int)(wallJumpData.TSJumpTime * 1000));
            //ToBack
            if (true) //if (Input.back)
            {
                DoWallJump(PlayerWallJumpStateEnum.ToBack, wallJumpData.TSJumpGravity,
                    wallJumpData.TSJumpForce, wallJumpData.TSJumpDirection, true);
                await UniTask.Delay((int)(wallJumpData.TBJumpTime * 1000));
            }
            //ToTop
            if (true) //if (Input.top)
            {
                DoWallJump(PlayerWallJumpStateEnum.ToTop, wallJumpData.TTJumpGravity,
                    wallJumpData.TTJumpForce, wallJumpData.TTJumpDirection, true);
                await UniTask.Delay((int)(wallJumpData.TTJumpTime * 1000));
            }
            //ToContinue
            if (true) //if (Input.continue)
            {
                DoWallJump(PlayerWallJumpStateEnum.ToContinue, wallJumpData.TCJumpGravity,
                    wallJumpData.TCJumpForce, wallJumpData.TCJumpDirection, true);
                await UniTask.Delay((int)(wallJumpData.TCJumpTime * 1000));
            }
            rb2d.gravityScale = wallJumpData.StopGravity;
            await WaitForJumpPeak();
            rb2d.gravityScale = wallJumpData.FallGravity;
        }

        private void DoWallJump(PlayerWallJumpStateEnum newState, float gravity, float force, Vector2 dir, bool isReversedDir)
        {
            _statesContainer.PlayerWallJumpSM.SetStateTo(newState);
            rb2d.gravityScale = gravity;
            Vector2 forceDir = CalculateForceDir(force, dir, isReversedDir);
            rb2d.AddForce(forceDir, ForceMode2D.Impulse);
        }

        private Vector2 CalculateForceDir(float force, Vector2 dir, bool isReversedDir)
        {
            int direction = _groundWallCollision.IsOnLeft ? 1 : -1;
            if (isReversedDir)
                direction *= -1;
            float jumpForce = Mathf.Sqrt(force * -2 * (Physics2D.gravity.y * rb2d.gravityScale));
            Vector2 forceDir = jumpForce * dir.normalized;
            return new Vector2(forceDir.x * direction, forceDir.y);
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

        private bool StateAbleJump()
        {
            return _statesContainer.LevelSM.CheckStateIs(LevelStateEnum.Start)
                   && _statesContainer.PlayerSM.CheckStateIs(PlayerStateEnum.Alive);
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
            if(!_statesContainer.PlayerMovementSM.CheckStateIs(PlayerMovementStateEnum.Run))
                _statesContainer.PlayerMovementSM.SetStateTo(PlayerMovementStateEnum.Idle);
            
            _isJumpEnd = true;
            _remainingJumps = jumpData.MaxJumps;
            _remainingAirJumps = jumpData.MaxAirJumps;
            _remainingWallJumps = wallJumpData.MaxJumps;
        }
    }
}