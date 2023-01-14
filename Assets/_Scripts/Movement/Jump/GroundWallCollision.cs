using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Movement.Jump
{
    public class GroundWallCollision : MonoBehaviour
    {
        [SerializeField, Required] private GroundEvents _groundEvents;
        [SerializeField, Required] private WallEvents[] _wallsEvents;
        public Action OnGroundLanded { get; set; }
        public bool IsOnGround { get; private set; }
        public bool IsOnWall { get; private set; }
        public bool IsOnLeft { get; private set; }
        private void OnEnable()
        {
            _groundEvents.OnGroundEntered += () => { IsOnGround = true; OnGroundLanded?.Invoke();};
            _groundEvents.OnGroundExited += () => { IsOnGround = false; };
            foreach (var wallEvent in _wallsEvents)
            {
                wallEvent.OnWallEntered += (isLeft) => 
                { 
                    IsOnWall = true;
                    IsOnLeft = isLeft;
                };
                wallEvent.OnWallExited += () => { IsOnWall = false; };
            }   
        }

        private void OnDisable()
        {
            _groundEvents.OnGroundEntered -= () => { IsOnGround = true; OnGroundLanded?.Invoke();};
            _groundEvents.OnGroundExited -= () => { IsOnGround = false; };
            foreach (var wallEvent in _wallsEvents)
            {
                wallEvent.OnWallEntered -= (isLeft) => 
                { 
                    IsOnWall = true;
                    IsOnLeft = isLeft;
                };
                wallEvent.OnWallExited -= () => { IsOnWall = false; };
            }   
        }
    }
}