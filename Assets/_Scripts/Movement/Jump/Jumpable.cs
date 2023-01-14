using KatanaRed.Utils.Scriptables;
using UnityEngine;

namespace KatanaRed.Movement.Jump
{
    public abstract class Jumpable
    {
        protected JumpSO jumpData;
        protected WallJumpSO wallJumpData;
        protected Rigidbody2D rb2d;
        protected int _remainingJumps;
        protected int _remainingAirJumps;
        protected int _remainingWallJumps;
        public Jumpable(JumpSO jumpData, WallJumpSO wallJumpData, Rigidbody2D rb2d)
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