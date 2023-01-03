using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.Movement
{
    public abstract class Jumpable
    {
        protected JumpableData data;
        protected Rigidbody2D rb2d;
        public Jumpable(JumpableData data, Rigidbody2D rb2d)
        {
            this.data = data;
            this.rb2d = rb2d;
        }
        
        public abstract void Jump(Vector2 direction);
    }
}