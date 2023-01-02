using KatanaRed.Abstracts;
using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.SubBehaviours
{
    public class PlayerJumpable : Jumpable
    {
        public PlayerJumpable(JumpableData data) : base(data)
        {
        }
        
        public override void Jump(Vector2 direction)
        {
            throw new System.NotImplementedException();
        }
    }
}