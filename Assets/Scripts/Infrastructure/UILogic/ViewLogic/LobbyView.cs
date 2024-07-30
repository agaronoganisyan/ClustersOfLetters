using Infrastructure.GameStateLogic;
using Infrastructure.UILogic.ViewModelLogic;
using Zenject;

namespace Infrastructure.UILogic.ViewLogic
{
    public class LobbyView : CanvasView
    {
        public override void Construct(DiContainer container)
        {
            base.Construct(container);
            
            _viewModel = container.Resolve<LobbyViewModel>();
        }

        public void OnStartMatch()
        {
            _gameStateMachine.SwitchState(GameState.Gameplay);
        }
    }
}