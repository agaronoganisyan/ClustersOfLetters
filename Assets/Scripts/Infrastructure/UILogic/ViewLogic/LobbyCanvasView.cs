using Infrastructure.GameStateLogic;
using Infrastructure.UILogic.ViewModelLogic;
using Zenject;

namespace Infrastructure.UILogic.ViewLogic
{
    public class LobbyCanvasView : CanvasView
    {
        public override void Construct(DiContainer container)
        {
            base.Construct(container);
            
            _viewModel = container.Resolve<LobbyCanvasViewModel>();
            _viewModel.SetView(this);
        }

        public void OnStartMatch()
        {
            _gameStateMachine.SwitchState(GameState.Gameplay);
        }
    }
}