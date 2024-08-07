using ClusterGameplayLogic.ValidatorLogic;
using Infrastructure.GameStateLogic;
using Zenject;
using UniRx;

namespace ClusterGameplayLogic.LevelLogic.HandlerLogic
{
    public class LevelHandler : ILevelHandler
    {
        private IGameValidator _gameValidator;
        private IGameStateMachine _gameStateMachine;
        
        public LevelHandler(DiContainer container)
        {
            _gameValidator = container.Resolve<IGameValidator>();
            _gameStateMachine = container.Resolve<IGameStateMachine>();

            _gameValidator.OnResultValidated.Subscribe((value) => _gameStateMachine.SwitchState(GameState.Debriefing));
        }
    }
}