using KatanaRed.Scriptables;
using UnityEngine;

namespace KatanaRed.Abstracts
{
    public abstract class Jumpable
    {
        protected JumpableData data;
        public Jumpable(JumpableData data)
        {
            this.data = data;
        }
        
        public abstract void Jump(Vector2 direction);
    }
}