using KatanaRed.Utils.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.States
{
    public class PlayerMovementStateMachine : BaseStateMachine
    {
        protected override void Awake()
        {
            base.Awake();
            InitStateMachine(new PlayerMovementState());
            SetStateTo(PlayerMovementStateEnum.Idle);
        }
    }
}