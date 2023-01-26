using KatanaRed.Input;
using KatanaRed.States;
using KatanaRed.Utils.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Movement.Run
{
    public class PlayerRunable : Runable
    {
        [SerializeField, Required] private MovementInput _movementInput;
        [SerializeField, Required] private StatesContainer _statesContainer;
   
        private void FixedUpdate()
        {
            Run(_movementInput.Movement, Time.fixedDeltaTime);
        }
        public override void Run(Vector2 direction, float dt)
        {
            if (!CanRun(direction))
                return;
            
            _statesContainer.PlayerMovementSM.SetStateTo(PlayerMovementStateEnum.Run);
            
            currentSpeed = CalculateCurrentSpeed(direction, dt);
            rb2d.velocity = new Vector2(CustomSign(direction.x) * currentSpeed, rb2d.velocity.y);
        }
        private bool CanRun(Vector2 direction)
        {
            if (HaveNoInput(direction))
            {
                _statesContainer.PlayerMovementSM.SetStateTo(PlayerMovementStateEnum.Idle);
                return false;
            }
            return StatesAbleRun();
        }

        private bool StatesAbleRun()
        {
            return _statesContainer.LevelSM.CheckStateIs(LevelStateEnum.Start)
                   && _statesContainer.PlayerSM.CheckStateIs(PlayerStateEnum.Alive)
                   && _statesContainer.PlayerMovementSM.CheckStateIs
                   (PlayerMovementStateEnum.Idle,
                       PlayerMovementStateEnum.Run,
                       PlayerMovementStateEnum.Jump,
                       PlayerMovementStateEnum.AirJump,
                       PlayerMovementStateEnum.WallJump,
                       PlayerMovementStateEnum.WallSlide)
                   && _statesContainer.PlayerWallJumpSM.CheckStateIs
                   (PlayerWallJumpStateEnum.None,
                       PlayerWallJumpStateEnum.ToTop);
        }
        
        private bool HaveNoInput(Vector2 direction)
        {
            return rb2d.velocity.x.Equals(0f) 
                   && currentSpeed.Equals(0f)
                   && direction.x.Equals(0f);
        }
    }
}