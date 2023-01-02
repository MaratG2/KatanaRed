using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.Abstracts
{
    public abstract class Movable
    {
        protected MovableData data;
        public Movable(MovableData data)
        {
            this.data = data;
        }
        
        public abstract void Move(Vector2 direction, float dt);
    }
}