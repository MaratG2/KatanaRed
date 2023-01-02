using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.Abstracts
{
    public abstract class Movable
    {
        protected MovableData data;
        protected Rigidbody2D rb2d;
        public Movable(MovableData data, Rigidbody2D rb2d)
        {
            this.data = data;
            this.rb2d = rb2d;
        }
        
        public abstract void Move(Vector2 direction, float dt);
    }
}