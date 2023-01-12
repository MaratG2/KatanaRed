using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.Movement
{
    public abstract class Jumpable
    {
        protected JumpableData jumpData;
        protected WallJumpableData wallJumpData;
        protected Rigidbody2D rb2d;
        protected int _remainingJumps;
        protected int _remainingAirJumps;
        protected int _remainingWallJumps;
        public Jumpable(JumpableData jumpData, WallJumpableData wallJumpData, Rigidbody2D rb2d)
        {
            this.jumpData = jumpData;
            this.wallJumpData = wallJumpData;
            this.rb2d = rb2d;
            _remainingJumps = jumpData.MaxJumps;
            _remainingAirJumps = jumpData.MaxAirJumps;
            _remainingWallJumps = wallJumpData.MaxJumps;
        }
        
        public abstract void JumpBegin();
        public abstract void JumpEnd();
    }
}