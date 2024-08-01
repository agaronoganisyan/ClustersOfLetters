using Cysharp.Threading.Tasks;
using Infrastructure.StateMachineLogic;
using Infrastructure.UILogic.DebriefingLogic.PanelLogic;
using Infrastructure.UILogic.LobbyLogic.PanelLogic;
using Infrastructure.UILogic.UIStateMachineLogic;
using Zenject;

namespace Infrastructure.GameStateLogic
{
    public class Lobby: GameBaseState<GameState>
    {
        private LobbyPanelViewModel _lobbyPanelViewModel;

        public Lobby(IStateMachine<GameState> stateMachine, DiContainer container) : base(stateMachine,container)
        {
            _lobbyPanelViewModel = container.Resolve<LobbyPanelViewModel>();

        }
        
        public override async UniTask Enter()
        {
            if (!_isSetuped)
            {
                _lobbyPanelViewModel.Setup(_container);
                
                _isSetuped = true;
            }
            
            _uiStateMachine.SwitchState(UIState.Lobby);
        }
    }
}