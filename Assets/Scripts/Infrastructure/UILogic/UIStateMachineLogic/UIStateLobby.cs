using Infrastructure.StateMachineLogic;
using Infrastructure.UILogic.ViewModelLogic;
using Zenject;

namespace Infrastructure.UILogic.UIStateMachineLogic
{
    public class UIStateLobby : UIBaseState<UIState>
    {
        public UIStateLobby(UIState state, IStateMachine<UIState> stateMachine, DiContainer container) : base(state, stateMachine, container)
        {
            _viewModel = container.Resolve<LobbyCanvasViewModel>();
        }
    }
}