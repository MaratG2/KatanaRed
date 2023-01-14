using UnityEngine;

namespace KatanaRed.Utils.Scriptables
{
    [CreateAssetMenu(fileName = "RunData", menuName = "KatanaRed/ScriptableObjects/RunData", order = 1)]
    public class RunSO : ScriptableObject
    {
        public float maxSpeed;
        public float acceleration;
        public float decceleration;
    }
}