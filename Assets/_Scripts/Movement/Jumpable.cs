using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.Movement
{
    public abstract class Jumpable
    {
        protected JumpableData data;
        protected Rigidbody2D rb2d;
        protected int _remainingJumps;
        protected int _remainingWallJumps;
        public Jumpable(JumpableData data, Rigidbody2D rb2d)
        {
            this.data = data;
            this.rb2d = rb2d;
            _remainingJumps = data.maxDefaultJumps;
            _remainingWallJumps = data.maxWallJumps;
        }
        
        public abstract void JumpBegin();
        public abstract void JumpEnd();
    }
}