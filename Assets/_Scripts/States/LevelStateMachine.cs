using KatanaRed.Utils.Enums;

namespace KatanaRed.States
{
    public class LevelStateMachine : BaseStateMachine
    {
        protected void Awake()
        {
            InitStateMachine(new LevelState(), LevelStateEnum.Start);
        }
    }
}