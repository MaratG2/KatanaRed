using KatanaRed.Abstracts;
using KatanaRed.Scriptables;
using KatanaRed.SubBehaviours;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Behaviours
{
    public class TestBehaviour : MonoBehaviour
    {
        [Header("Dependencies")] 
        [SerializeField, Required] private Rigidbody2D _rb2d;
        [SerializeField, Required] private MovableData _movableData;
        [SerializeField, Required] private JumpableData _jumpableData;
        private Movable _movable;
        private Jumpable _jumpable;
        
        private void Awake()
        {
            _movable = new PlayerMovable(_movableData, _rb2d);
            _jumpable = new PlayerJumpable(_jumpableData, _rb2d);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                _jumpable.Jump(new Vector2(0, 1));
        }

        private void FixedUpdate()
        {
            _movable.Move(new Vector2(1, 0), Time.fixedDeltaTime);
        }
    }
}