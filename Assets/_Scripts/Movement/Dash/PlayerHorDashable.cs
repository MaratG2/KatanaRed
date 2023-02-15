using Cysharp.Threading.Tasks;
using KatanaRed.Input;
using KatanaRed.States;
using KatanaRed.Utils.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Movement.Dash
{
    public class PlayerHorDashable : HorDashable
    {
        [SerializeField, Required] private MovementInput _movementInput;
        [SerializeField, Required] private StatesContainer _statesContainer;
        
        private void OnEnable()
        {
            _movementInput.OnHorizontalDash += Dash;
        }

        private void OnDisable()
        {
            _movementInput.OnHorizontalDash -= Dash;
        }
        public override void Dash()
        {
            if (!StateAbleDash() || !_isDashReady)
                return;
            HorizontalDashAsync();
        }

        private async UniTask HorizontalDashAsync()
        {
            _isDashReady = false;
            _statesContainer.PlayerMovementSM.SetStateTo(PlayerMovementStateEnum.Dash);
            rb2d.AddForce(
                dashData.DashStrength * dashData.DashDirection,
                ForceMode2D.Impulse);
            await UniTask.Delay((int)(dashData.DashTime * 1000));
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            _statesContainer.PlayerMovementSM.SetStateTo(PlayerMovementStateEnum.Idle);
            await UniTask.Delay(
                (int)(dashData.DashCooldown * 1000)
                - (int)(dashData.DashTime * 1000));
            _isDashReady = true;
        }
        
        private bool StateAbleDash()
        {
            return _statesContainer.LevelSM.CheckStateIs(LevelStateEnum.Start)
                   && _statesContainer.PlayerSM.CheckStateIs(PlayerStateEnum.Alive);
        }
    }
}