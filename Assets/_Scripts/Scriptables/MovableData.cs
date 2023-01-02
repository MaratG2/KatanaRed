using UnityEngine;

namespace KatanaRed.Scriptables
{
    [CreateAssetMenu(fileName = "MovableData", menuName = "ScriptableObjects/MovableData", order = 1)]
    public class MovableData : ScriptableObject
    {
        public float maxSpeed;
        public float acceleration;
        public float decceleration;
    }
}