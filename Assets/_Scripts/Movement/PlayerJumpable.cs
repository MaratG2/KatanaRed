using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.Movement
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