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
            if (rb2d.velocity.x.Equals(0f) && currentSpeed.Equals(0f) && direction.x.Equals(0f))
                return;
            
            currentSpeed = CalculateCurrentSpeed(direction, dt);
            rb2d.velocity = new Vector2(CustomSign(direction.x) * currentSpeed, rb2d.velocity.y);
        }
    }
}