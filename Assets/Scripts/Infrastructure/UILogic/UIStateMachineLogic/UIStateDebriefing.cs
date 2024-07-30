using Infrastructure.StateMachineLogic;
using Infrastructure.UILogic.ViewModelLogic;
using Zenject;

namespace Infrastructure.UILogic.UIStateMachineLogic
{
    public class UIStateDebriefing : UIBaseState<UIState>
    {
        public UIStateDebriefing(UIState state, IStateMachine<UIState> stateMachine, DiContainer container) : base(state, stateMachine, container)
        {
            _viewModel = container.Resolve<DebriefingViewModel>();
        }
    }
}