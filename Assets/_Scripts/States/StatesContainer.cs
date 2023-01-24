using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.States
{
    public class StatesContainer : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField, Required] private PlayerStateMachine _playerSM;
        [SerializeField, Required] private PlayerMovementStateMachine _playerMovementSM;
        [SerializeField, Required] private PlayerWallJumpStateMachine _playerWallJumpSM;
        [SerializeField, Required] private LevelStateMachine _levelSM;

        public PlayerStateMachine PlayerSM => _playerSM;
        public PlayerMovementStateMachine PlayerMovementSM => _playerMovementSM;
        public PlayerWallJumpStateMachine PlayerWallJumpSM => _playerWallJumpSM;
        public LevelStateMachine LevelSM => _levelSM;
    }
}