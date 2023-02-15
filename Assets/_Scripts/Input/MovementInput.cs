using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KatanaRed.Input
{
    public class MovementInput : MonoBehaviour
    {
        public Vector2 Movement { get; private set; } = Vector2.zero;
        public int Direction { get; private set; } = 1;
        public Action OnJumpBegin;
        public Action OnJumpEnd;
        public Action OnHorizontalDash;
        public Action OnVerticalDash;
        private int _jumpPhases = 0;
        private int _horDashPhases = 0;
        private int _vertDashPhases = 0;

        public void PlayerMove(InputAction.CallbackContext context)
        {
            Movement = context.ReadValue<Vector2>();

            if (Movement.x > 0f)
                Direction = 1;
            else if (Movement.x < 0f)
                Direction = -1;
        }

        public void PlayerJump(InputAction.CallbackContext context)
        {
            _jumpPhases++;
            if (_jumpPhases == 2)
            {
                OnJumpBegin?.Invoke();
            }
            else if (_jumpPhases == 3)
            {
                OnJumpEnd?.Invoke();
                _jumpPhases = 0;
            }
        }

        public void PlayerHorizontalDash(InputAction.CallbackContext context)
        {
            _horDashPhases++;
            if (_horDashPhases == 2)
                OnHorizontalDash?.Invoke();
            else if (_horDashPhases == 3)
                _horDashPhases = 0;
        }
        
        public void PlayerVerticalDash(InputAction.CallbackContext context)
        {
            if (context.ReadValue<float>() < 0.7f)
            {
                if (_vertDashPhases > 0)
                    _vertDashPhases = 0;
                return;
            }
            
            _vertDashPhases++;
            if (_vertDashPhases == 2)
                OnVerticalDash?.Invoke();
            else if (_vertDashPhases == 3)
                _vertDashPhases = 0;
        }
    }
}