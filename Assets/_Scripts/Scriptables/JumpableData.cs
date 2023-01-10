using UnityEngine;

namespace KatanaRed.Scriptables
{
    [CreateAssetMenu(fileName = "JumpableData", menuName = "ScriptableObjects/JumpableData", order = 1)]
    public class JumpableData : ScriptableObject
    {
        public float minJumpHeight = 1f;
        public float maxJumpHeight = 2.5f;
        public float jumpGravity = 4f;
        public float fallGravity = 6f;
        public float stopGravity = 15f;
        public int maxDefaultJumps = 1;
        public int maxAirJumps = 0;
        public int maxWallJumps = 1;
    }
}