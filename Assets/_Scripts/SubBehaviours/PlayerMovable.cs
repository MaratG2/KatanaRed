using KatanaRed.Abstracts;
using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.SubBehaviours
{
    public class PlayerMovable : Movable
    {
        private float _oldSign = 1f;
        public PlayerMovable(MovableData data, Rigidbody2D rb2d) : base(data, rb2d)
        {
        }
        
        public override void Move(Vector2 direction, float dt)
        {
            if (rb2d.velocity.x.Equals(0f) && direction.x.Equals(0f))
                return;
            
            currentSpeed = CalculateCurrentSpeed(direction, dt);
            rb2d.velocity = new Vector2(CustomSign(direction.x) * currentSpeed, rb2d.velocity.y);
        }

        private float CalculateCurrentSpeed(Vector2 direction, float dt)
        {
            if (Mathf.Abs(direction.x) > 0f)
                currentSpeed += data.acceleration * dt;
            else 
                currentSpeed -= data.decceleration * dt;

            currentSpeed = Mathf.Clamp(currentSpeed, 0f, data.maxSpeed);
            return currentSpeed;
        }

        private float CustomSign(float value)
        {
            float sign = _oldSign;
            Debug.Log(value);
            if (value > 0f)
                sign = 1f;
            else if(value < -0f)
                sign = -1f;
            _oldSign = sign;
            return _oldSign;
        }
    }
}