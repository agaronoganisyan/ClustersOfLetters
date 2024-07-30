using Infrastructure.StateMachineLogic;
using Infrastructure.StateMachineLogic.Async;
using Zenject;

namespace Infrastructure.GameStateLogic
{
    public class GameStateMachine : IGameStateMachine
    {
        private IStateMachine<GameState> _stateMachine;
        
        public GameStateMachine(DiContainer container)
        {
            _stateMachine = new AsyncStateMachine<GameState>();

            _stateMachine.Add(GameState.Lobby, new Lobby(_stateMachine, container));
            _stateMachine.Add(GameState.Gameplay, new Gameplay(_stateMachine, container));
            _stateMachine.Add(GameState.Debriefing, new Debriefing(_stateMachine, container));
        }

        public void InitializeMachine()
        {
            _stateMachine.Initialize(GameState.Lobby);
        }

        public void SwitchState(GameState gameState)
        {
            _stateMachine.TransitToState(gameState);
        }
    }
}