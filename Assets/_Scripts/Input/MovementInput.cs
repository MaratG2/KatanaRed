using UnityEngine;
using UnityEngine.InputSystem;

namespace KatanaRed.Input
{
    public class MovementInput : MonoBehaviour
    {
        public Vector2 Movement { get; private set; } = Vector2.zero;

        public void PlayerMove(InputAction.CallbackContext context)
        {
            Movement = context.ReadValue<Vector2>();
        }
    }
}