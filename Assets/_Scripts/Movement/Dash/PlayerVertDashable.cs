using KatanaRed.Input;
using KatanaRed.States;
using KatanaRed.Utils.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Movement.Dash
{
    public class PlayerVertDashable : VertDashable
    {
        [SerializeField, Required] private MovementInput _movementInput;
        [SerializeField, Required] private StatesContainer _statesContainer;
        
        private void OnEnable()
        {
            _movementInput.OnVerticalDash += Dash;
        }

        private void OnDisable()
        {
            _movementInput.OnVerticalDash -= Dash;
        }
        public override void Dash()
        {
            if (!StateAbleDash())
                return;
            Debug.Log("Vertical Dash");
        }
        
        private bool StateAbleDash()
        {
            return _statesContainer.LevelSM.CheckStateIs(LevelStateEnum.Start)
                   && _statesContainer.PlayerSM.CheckStateIs(PlayerStateEnum.Alive);
        }
    }
}