using UnityEngine;

namespace KatanaRed.Interfaces
{
    public interface IMovable
    {
        void Move(Vector2 direction, float speed, float dt);
    }
}