using KatanaRed.Movement.Run;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace KatanaRed.Utils.Debug
{
    public class RunVelocityDebugger : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField, Required] private bool _isDebugOn = false;
        [SerializeField, Required] private Runable _runable;
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
            Vector2 end2 =  new Vector2(_runable.Rb2d.velocity.x, 0f);
            Vector3 end3 = new Vector3(end2.x, end2.y, -0.03f);
            _movementLine.SetPosition(0, start);
            _movementLine.SetPosition(1, end3);
        }
    }
}