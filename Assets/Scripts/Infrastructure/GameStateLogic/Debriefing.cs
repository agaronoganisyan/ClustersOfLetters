using Cysharp.Threading.Tasks;
using Infrastructure.StateMachineLogic;
using Infrastructure.UILogic.DebriefingLogic.PanelLogic;
using Infrastructure.UILogic.UIStateMachineLogic;
using Zenject;

namespace Infrastructure.GameStateLogic
{
    public class Debriefing : GameBaseState<GameState>
    {
        private DebriefingPanelViewModel _debriefingPanelViewModel;
        
        public Debriefing(IStateMachine<GameState> stateMachine, DiContainer container) : base(stateMachine, container)
        {
            _debriefingPanelViewModel = container.Resolve<DebriefingPanelViewModel>();

        }
        
        public override async UniTask Enter()
        {
            if (!_isSetuped)
            {
                _debriefingPanelViewModel.Setup(_container);
                
                _isSetuped = true;
            }
            
            _uiStateMachine.SwitchState(UIState.Debriefing);
        }
    }
}