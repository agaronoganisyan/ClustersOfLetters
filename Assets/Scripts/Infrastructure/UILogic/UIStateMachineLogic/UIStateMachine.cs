using Infrastructure.StateMachineLogic;
using Infrastructure.StateMachineLogic.Async;
using Zenject;

namespace Infrastructure.UILogic.UIStateMachineLogic
{
    public class UIStateMachine : IUIStateMachine
    {
        private IStateMachine<UIState> _stateMachine;
        
        public UIStateMachine(DiContainer container)
        {
            _stateMachine = new AsyncStateMachine<UIState>();

            _stateMachine.Add(UIState.Lobby, new UIStateLobby(UIState.Lobby, _stateMachine, container));
            _stateMachine.Add(UIState.Gameplay, new UIStateGameplay(UIState.Gameplay, _stateMachine, container));
            _stateMachine.Add(UIState.Debriefing, new UIStateDebriefing(UIState.Debriefing, _stateMachine, container));
        }

        public void SwitchState(UIState gameState)
        {
            _stateMachine.TransitToState(gameState);
        }
    }
}