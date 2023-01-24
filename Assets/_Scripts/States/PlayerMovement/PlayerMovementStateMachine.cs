using KatanaRed.Utils.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.States
{
    public class PlayerMovementStateMachine : BaseStateMachine
    {
        protected void Awake()
        {
            InitStateMachine(new PlayerMovementState(), PlayerMovementStateEnum.Idle);
        }
    }
}