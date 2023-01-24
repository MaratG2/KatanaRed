using UnityEngine;

namespace KatanaRed.Utils.Scriptables
{
    [CreateAssetMenu(fileName = "WallJumpData", menuName = "KatanaRed/ScriptableObjects/WallJumpData", order = 1)]
    public class WallJumpSO : ScriptableObject
    {
        [Header("ToSide")]
        [SerializeField]
        private float _tsJumpForce = 1f;
        [SerializeField]
        private Vector2 _tsJumpDirection = Vector2.right;
        [SerializeField]
        private float _tsJumpTime = 1f;
        [SerializeField]
        private float _tsJumpGravity = 4f;
        [Header("ToBack")]
        [SerializeField]
        private float _tbJumpForce = 1f;
        [SerializeField]
        private Vector2 _tbJumpDirection = Vector2.right;
        [SerializeField]
        private float _tbJumpTime = 1f;
        [SerializeField]
        private float _tbJumpGravity = 4f;
        [Header("ToTop")]
        [SerializeField]
        private float _ttJumpForce = 1f;
        [SerializeField]
        private Vector2 _ttJumpDirection = Vector2.right;
        [SerializeField]
        private float _ttJumpTime = 1f;
        [SerializeField]
        private float _ttJumpGravity = 4f;
        [Header("ToContinue")]
        [SerializeField]
        private float _tcJumpForce = 1f;
        [SerializeField]
        private Vector2 _tcJumpDirection = Vector2.right;
        [SerializeField]
        private float _tcJumpTime = 1f;
        [SerializeField]
        private float _tcJumpGravity = 4f;
        [Header("Common")]
        [SerializeField]
        private float _fallGravity = 6f;
        [SerializeField]
        private float _stopGravity = 15f;
        [SerializeField]
        private int _maxJumps = 1;

        public float TSJumpForce => _tsJumpForce;
        public Vector2 TSJumpDirection => _tsJumpDirection;
        public float TSJumpTime => _tsJumpTime;
        public float TSJumpGravity => _tsJumpGravity;
        public float TBJumpForce => _tbJumpForce;
        public Vector2 TBJumpDirection => _tbJumpDirection;
        public float TBJumpTime => _tbJumpTime;
        public float TBJumpGravity => _tbJumpGravity;
        public float TTJumpForce => _ttJumpForce;
        public Vector2 TTJumpDirection => _ttJumpDirection;
        public float TTJumpTime => _ttJumpTime;
        public float TTJumpGravity => _ttJumpGravity;
        public float TCJumpForce => _tcJumpForce;
        public Vector2 TCJumpDirection => _tcJumpDirection;
        public float TCJumpTime => _tcJumpTime;
        public float TCJumpGravity => _tcJumpGravity;
        public float FallGravity => _fallGravity;
        public float StopGravity => _stopGravity;
        public int MaxJumps => _maxJumps;
    }
}