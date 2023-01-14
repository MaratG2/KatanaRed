using KatanaRed.Utils.Scriptables;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Movement.Run
{
    public abstract class Movable : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField, Required] protected RunSO runData;
        [SerializeField, Required] protected Rigidbody2D rb2d;
        public Rigidbody2D Rb2d => rb2d;
        protected float currentSpeed = 0;
        private float _oldSign = 1f;

        public abstract void Move(Vector2 direction, float dt, bool canMove);
        
        protected float CalculateCurrentSpeed(Vector2 direction, float dt)
        {
            if (Mathf.Abs(direction.x) > 0f)
                currentSpeed += runData.acceleration * dt;
            else 
                currentSpeed -= runData.decceleration * dt;

            currentSpeed = Mathf.Clamp(currentSpeed, 0f, runData.maxSpeed);
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