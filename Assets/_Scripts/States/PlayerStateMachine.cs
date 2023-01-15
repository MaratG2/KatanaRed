using KatanaRed.Utils.Enums;

namespace KatanaRed.States
{
    public class PlayerStateMachine : BaseStateMachine
    {
        protected void Awake()
        {
            InitStateMachine(new PlayerState());
            SetStateTo(PlayerStateEnum.Alive);
        }
    }
}