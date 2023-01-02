using KatanaRed.Abstracts;
using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.SubBehaviours
{
    public class PlayerJumpable : Jumpable
    {
        public PlayerJumpable(JumpableData data, Rigidbody2D rb2d) : base(data, rb2d)
        {
        }
        
        public override void Jump(Vector2 direction)
        {
            throw new System.NotImplementedException();
        }
    }
}