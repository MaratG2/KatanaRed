using System;
using KatanaRed.Utils.Scriptables;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Movement.Jump
{
    public abstract class Jumpable : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField, Required] protected JumpSO jumpData;
        [SerializeField, Required] protected WallJumpSO wallJumpData;
        [SerializeField, Required] protected Rigidbody2D rb2d;
        protected int _remainingJumps;
        protected int _remainingAirJumps;
        protected int _remainingWallJumps;

        protected virtual void Awake()
        {
            _remainingJumps = jumpData.MaxJumps;
            _remainingAirJumps = jumpData.MaxAirJumps;
            _remainingWallJumps = wallJumpData.MaxJumps;
        }

        public abstract void JumpBegin();
        public abstract void JumpEnd();
    }
}