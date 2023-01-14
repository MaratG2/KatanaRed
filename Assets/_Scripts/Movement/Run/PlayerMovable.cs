using KatanaRed.Input;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Movement.Run
{
    public class PlayerMovable : Movable
    {
        [SerializeField, Required] private MovementInput _movementInput;
        public override void Move(Vector2 direction, float dt, bool canMove)
        {
            if (!canMove || rb2d.velocity.x.Equals(0f) && currentSpeed.Equals(0f) && direction.x.Equals(0f))
                return;
            
            currentSpeed = CalculateCurrentSpeed(direction, dt);
            rb2d.velocity = new Vector2(CustomSign(direction.x) * currentSpeed, rb2d.velocity.y);
        }

        private void Awake()
        {
            _movementInput.canMove = true;
        }
        private void FixedUpdate()
        {
           Move(_movementInput.Movement, Time.fixedDeltaTime, _movementInput.canMove);
        }
    }
}