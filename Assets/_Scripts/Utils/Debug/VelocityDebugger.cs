using KatanaRed.Behaviours;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Utils.Debug
{
    public class VelocityDebugger : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField, Required] private bool _isDebugOn = false;
        [SerializeField, Required] private PlayerBehaviour _playerBehaviour;
        [SerializeField, Required] private LineRenderer _movementLine;
        
        private void FixedUpdate()
        {
            if (!_isDebugOn)
                return;
            DrawDebugRays();
        }

        private void DrawDebugRays()
        {
            Vector3 start = new Vector3(0f, 0f, -0.03f);
            Vector2 end2 =  new Vector2(_playerBehaviour.Movable.Rb2d.velocity.x, 0f);
            Vector3 end3 = new Vector3(end2.x, end2.y, -0.03f);
            _movementLine.SetPosition(0, start);
            _movementLine.SetPosition(1, end3);
        }
    }
}