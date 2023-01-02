using UnityEngine;

namespace KatanaRed.Scriptables
{
    [CreateAssetMenu(fileName = "JumpableData", menuName = "ScriptableObjects/JumpableData", order = 1)]
    public class JumpableData : ScriptableObject
    {
        public float jumpStrength;
    }
}