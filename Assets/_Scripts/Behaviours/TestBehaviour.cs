using KatanaRed.Interfaces;
using UnityEngine;

namespace KatanaRed.Behaviours
{
    public class TestBehaviour : MonoBehaviour
    {
        private IMovable _movable;
        private IJumpable _jumpable;
        private void Awake()
        {
            _movable = GetComponent<IMovable>();
            _jumpable = GetComponent<IJumpable>();
        }

        private void Update()
        {
            
        }

        private void FixedUpdate()
        {
            _movable.Move(new Vector2(1, 0), 1, Time.fixedDeltaTime);
        }
    }
}