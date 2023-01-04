using UnityEngine;

namespace KatanaRed.Scriptables
{
    [CreateAssetMenu(fileName = "JumpableData", menuName = "ScriptableObjects/JumpableData", order = 1)]
    public class JumpableData : ScriptableObject
    {
        public float minJumpStrength;
        public float maxJumpStrength;
        public float minMaxTime;
        public int maxDefaultJumps = 1;
        public int maxWallJumps = 1;
    }
}