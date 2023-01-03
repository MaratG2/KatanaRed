using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.Abstracts
{
    public abstract class Movable
    {
        public Rigidbody2D Rb2d => rb2d;
        protected MovableData data;
        protected Rigidbody2D rb2d;
        protected float currentSpeed = 0;
        private float _oldSign = 1f;
        
        public Movable(MovableData data, Rigidbody2D rb2d)
        {
            this.data = data;
            this.rb2d = rb2d;
        }
        
        public abstract void Move(Vector2 direction, float dt);
        
        protected float CalculateCurrentSpeed(Vector2 direction, float dt)
        {
            if (Mathf.Abs(direction.x) > 0f)
                currentSpeed += data.acceleration * dt;
            else 
                currentSpeed -= data.decceleration * dt;

            currentSpeed = Mathf.Clamp(currentSpeed, 0f, data.maxSpeed);
            return currentSpeed;
        }
        
        protected float CustomSign(float value)
        {
            float sign = _oldSign;
            if (value > 0f)
                sign = 1f;
            else if(value < 0f)
                sign = -1f;

            _oldSign = sign;
            return _oldSign;
        }
    }
}