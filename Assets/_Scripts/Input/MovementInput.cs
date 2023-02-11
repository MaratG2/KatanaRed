using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KatanaRed.Input
{
    public class MovementInput : MonoBehaviour
    {
        public Vector2 Movement { get; private set; } = Vector2.zero;
        public Action OnJumpBegin;
        public Action OnJumpEnd;
        public Action OnHorizontalDash;
        public Action OnVerticalDash;
        private int _jumpPhases = 0;

        public void PlayerMove(InputAction.CallbackContext context)
        {
            Movement = context.ReadValue<Vector2>();
        }

        public void PlayerJump(InputAction.CallbackContext context)
        {
            _jumpPhases++;
            
            if (_jumpPhases == 2)
                OnJumpBegin?.Invoke();
            else if (_jumpPhases == 3)
            {
                OnJumpEnd?.Invoke();
                _jumpPhases = 0;
            }
        }

        public void PlayerHorizontalDash(InputAction.CallbackContext context)
        {
            OnHorizontalDash?.Invoke();
        }
        
        public void PlayerVerticalDash(InputAction.CallbackContext context)
        {
            OnVerticalDash?.Invoke();
        }
    }
}