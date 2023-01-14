using KatanaRed.Movement.Jump;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace KatanaRed.Utils.Debug
{
    public class JumpHitboxesDebugger : MonoBehaviour
    {
        [SerializeField] private bool _isDebugOn;
        [SerializeField, Required] private GroundWallCollision _groundWallCollision;
        [SerializeField, Required] private SpriteRenderer _bottomHitbox;
        [SerializeField, Required] private SpriteRenderer _leftHitbox;
        [SerializeField, Required] private SpriteRenderer _rightHitbox;

        private void Update()
        {
            if (!_isDebugOn)
                return;
            
            _bottomHitbox.enabled = _groundWallCollision.IsOnGround;
            _leftHitbox.enabled = _groundWallCollision.IsOnWall && _groundWallCollision.IsOnLeft;
            _rightHitbox.enabled = _groundWallCollision.IsOnWall && !_groundWallCollision.IsOnLeft;
        }
    }
}