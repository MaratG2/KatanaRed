using KatanaRed.Abstracts;
using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.SubBehaviours
{
    public class PlayerMovable : Movable
    {
        public PlayerMovable(MovableData data, Rigidbody2D rb2d) : base(data, rb2d)
        {
        }
        
        public override void Move(Vector2 direction, float dt)
        {
            if (direction == Vector2.zero)
                return;
            
            currentSpeed = CalculateCurrentSpeed(direction, dt);
            rb2d.velocity = direction.normalized * currentSpeed;
        }

        private float CalculateCurrentSpeed(Vector2 direction, float dt)
        {
            if (Mathf.Abs(direction.x) > 0)
                currentSpeed += data.acceleration * dt;
            else 
                currentSpeed -= data.decceleration * dt;

            currentSpeed = Mathf.Clamp(currentSpeed, 0f, data.maxSpeed);
            return currentSpeed;
        }
    }
}