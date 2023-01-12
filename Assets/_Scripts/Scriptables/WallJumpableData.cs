using UnityEngine;

namespace KatanaRed.Scriptables
{
    [CreateAssetMenu(fileName = "WallJumpableData", menuName = "ScriptableObjects/WallJumpableData", order = 1)]
    public class WallJumpableData : ScriptableObject
    {
        [SerializeField]
        private float _jumpForce = 1f;
        [SerializeField]
        private Vector2 _jumpPositiveDirection = Vector2.right;
        [SerializeField]
        private float _jumpTime = 1f;
        [SerializeField]
        private float _fallTime = 1f;
        [SerializeField]
        private float _jumpGravity = 4f;
        [SerializeField]
        private float _fallGravity = 6f;
        [SerializeField]
        private float _stopGravity = 15f;
        [SerializeField]
        private int _maxJumps = 1;

        public float JumpForce => _jumpForce;
        public Vector2 JumpPositiveDirection => _jumpPositiveDirection;
        public float JumpTime => _jumpTime;
        public float FallTime => _fallTime;
        public float JumpGravity => _jumpGravity;
        public float FallGravity => _fallGravity;
        public float StopGravity => _stopGravity;
        public int MaxJumps => _maxJumps;
    }
}