using UnityEngine;

namespace KatanaRed.Utils.Scriptables
{ 
    public abstract class DashSO : ScriptableObject
    {
        [SerializeField]
        private float _dashCooldown = 1f;
        [SerializeField]
        private Vector2 _dashDirection = Vector2.right;
        [SerializeField]
        private float _dashStrength = 1f;
        [SerializeField] 
        private float _dashTime = 0.2f;
        
        public float DashCooldown => _dashCooldown;
        public Vector2 DashDirection => _dashDirection;
        public float DashStrength => _dashStrength;
        public float DashTime => _dashTime;
    }
}