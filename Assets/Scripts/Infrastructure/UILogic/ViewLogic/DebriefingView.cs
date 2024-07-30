using Infrastructure.GameStateLogic;
using Infrastructure.UILogic.ViewModelLogic;
using Zenject;

namespace Infrastructure.UILogic.ViewLogic
{
    public class DebriefingView : CanvasView
    {
        public override void Construct(DiContainer container)
        {
            base.Construct(container);
            
            _viewModel = container.Resolve<DebriefingViewModel>();
        }
        
        public void OnToLobby()
        {
            _gameStateMachine.SwitchState(GameState.Lobby);
        }
    }
}