using UnityEngine;

namespace KatanaRed.Interfaces
{
    public interface IJumpable
    {
        void Jump(Vector2 direction, float strength);
    }
}