using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Movement
{
    public class JumpHitboxes : MonoBehaviour
    {
        [SerializeField, Required] private JumpEventWrapper _groundJump;
        [SerializeField, Required] private WallJumpEventWrapper[] _sideWallsJump;
        public bool IsOnGround { get; private set; }
        public bool IsOnWall { get; private set; }
        public bool IsOnLeft { get; private set; }
        
        private void OnEnable()
        {
            _groundJump.OnGroundEntered += () => { IsOnGround = true; };
            _groundJump.OnGroundExited += () => { IsOnGround = false; };
            foreach (var sideWallJump in _sideWallsJump)
            {
                sideWallJump.OnWallEntered += (isLeft) => 
                { 
                    IsOnWall = true;
                    IsOnLeft = isLeft;
                };
                sideWallJump.OnWallExited += () => { IsOnWall = false; };
            }   
        }

        private void OnDisable()
        {
            _groundJump.OnGroundEntered -= () => { IsOnGround = true; };
            _groundJump.OnGroundExited -= () => { IsOnGround = false; };
            foreach (var sideWallJump in _sideWallsJump)
            {
                sideWallJump.OnWallEntered -= (isLeft) => 
                { 
                    IsOnWall = true;
                    IsOnLeft = isLeft;
                };
                sideWallJump.OnWallExited -= () => { IsOnWall = false; };
            }   
        }
    }
}