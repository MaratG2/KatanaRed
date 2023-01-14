using KatanaRed.Movement.Jump;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Utils.Debug
{
    public class JumpHitboxesDebugger : MonoBehaviour
    {
        [SerializeField] private bool _isDebugOn;
        [SerializeField, Required] private JumpHitboxes _jumpHitboxes;
        [SerializeField, Required] private SpriteRenderer _bottomHitbox;
        [SerializeField, Required] private SpriteRenderer _leftHitbox;
        [SerializeField, Required] private SpriteRenderer _rightHitbox;

        private void Update()
        {
            if (!_isDebugOn)
                return;
            
            _bottomHitbox.enabled = _jumpHitboxes.IsOnGround;
            _leftHitbox.enabled = _jumpHitboxes.IsOnWall && _jumpHitboxes.IsOnLeft;
            _rightHitbox.enabled = _jumpHitboxes.IsOnWall && !_jumpHitboxes.IsOnLeft;
        }
    }
}