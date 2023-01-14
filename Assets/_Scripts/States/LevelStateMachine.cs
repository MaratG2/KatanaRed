using KatanaRed.Utils.Enums;

namespace KatanaRed.States
{
    public class LevelStateMachine : BaseStateMachine
    {
        protected override void Awake()
        {
            base.Awake();
            InitStateMachine(new LevelState());
            SetStateTo(LevelStateEnum.Start);
        }
    }
}