using System;
using Cysharp.Threading.Tasks;
using Infrastructure.StateMachineLogic;
using Infrastructure.StateMachineLogic.Async;
using Infrastructure.UILogic.UIStateMachineLogic;
using Zenject;

namespace Infrastructure.GameStateLogic
{
    public enum GameState
    {
        None,
        Lobby,
        Gameplay,
        Debriefing
    }
    
    public class GameBaseState<State> : IAsyncState<State> where State : Enum
    {
        public State StateKey { get; }
        
        protected readonly IStateMachine<GameState> _stateMachine;
        protected IUIStateMachine _uiStateMachine;
        
        protected GameBaseState(IStateMachine<GameState> stateMachine, DiContainer container)
        {
            _stateMachine = stateMachine;
            _uiStateMachine = container.Resolve<IUIStateMachine>();
        }

        public virtual async UniTask Enter()
        {
        }

        public virtual async UniTask Exit()
        {
        }
        
        public virtual void Update()
        {
        }
    }
}