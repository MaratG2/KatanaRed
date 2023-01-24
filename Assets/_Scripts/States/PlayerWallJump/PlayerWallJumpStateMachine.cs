using KatanaRed.Utils.Enums;

namespace KatanaRed.States
{
    public class PlayerWallJumpStateMachine : BaseStateMachine
    {
        protected void Awake()
        {
            InitStateMachine(new PlayerWallJumpState(), 
                PlayerWallJumpStateEnum.None);
        }
    }
}