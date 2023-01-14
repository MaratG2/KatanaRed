using KatanaRed.Utils.Enums;

namespace KatanaRed.States
{
    public class PlayerStateMachine : BaseStateMachine
    {
        protected override void Awake()
        {
            base.Awake();
            InitStateMachine(new PlayerState());
            SetStateTo(PlayerStateEnum.Alive);
        }
    }
}