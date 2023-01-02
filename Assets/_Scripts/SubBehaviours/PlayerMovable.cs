using KatanaRed.Abstracts;
using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.SubBehaviours
{
    public class PlayerMovable : Movable
    {
        public PlayerMovable(MovableData data) : base(data)
        {
        }
        
        public override void Move(Vector2 direction, float dt)
        {
            throw new System.NotImplementedException();
        }
    }
}