using Infrastructure.GameStateLogic;
using Zenject;

namespace Infrastructure.GameHandlerLogic
{
    public class GameHandler : IGameHandler
    {
        private IGameStateMachine _gameStateMachine;
        
        public GameHandler(DiContainer container)
        {
            _gameStateMachine = container.Resolve<IGameStateMachine>();
        }

        public void SwitchState(GameState state)
        {
            _gameStateMachine.SwitchState(state);
        }
    }
}