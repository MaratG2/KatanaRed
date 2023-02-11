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
            if (!StateAbleDash())
                return;
            Debug.Log("Horizontal Dash");
        }
        
        private bool StateAbleDash()
        {
            return _statesContainer.LevelSM.CheckStateIs(LevelStateEnum.Start)
                   && _statesContainer.PlayerSM.CheckStateIs(PlayerStateEnum.Alive);
        }
    }
}