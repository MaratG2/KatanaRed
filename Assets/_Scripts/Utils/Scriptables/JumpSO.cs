using UnityEngine;

namespace KatanaRed.Utils.Scriptables
{
    [CreateAssetMenu(fileName = "JumpData", menuName = "KatanaRed/ScriptableObjects/JumpData", order = 1)]
    public class JumpSO : ScriptableObject
    {
        [SerializeField]
        private float _minJumpHeight = 1f;
        [SerializeField]
        private float _maxJumpHeight = 2.5f;
        [SerializeField]
        private float _jumpGravity = 4f;
        [SerializeField]
        private float _fallGravity = 6f;
        [SerializeField]
        private float _stopGravity = 15f;
        [SerializeField]
        private int _maxJumps = 1;
        [SerializeField]
        private int _maxAirJumps = 0;
        
        public float MinJumpHeight => _minJumpHeight;
        public float MaxJumpHeight => _maxJumpHeight;
        public float JumpGravity => _jumpGravity;
        public float FallGravity => _fallGravity;
        public float StopGravity => _stopGravity;
        public int MaxJumps => _maxJumps;
        public int MaxAirJumps => _maxAirJumps;
    }
}