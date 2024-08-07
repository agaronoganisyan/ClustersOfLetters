using ClusterGameplayLogic.ValidatorLogic;
using Infrastructure.GameHandlerLogic;
using Infrastructure.GameStateLogic;
using Zenject;
using UniRx;

namespace ClusterGameplayLogic.LevelLogic.HandlerLogic
{
    public class LevelHandler : ILevelHandler
    {
        private IGameValidator _gameValidator;
        private IGameHandler _gameHandler;
        
        public LevelHandler(DiContainer container)
        {
            _gameValidator = container.Resolve<IGameValidator>();
            _gameHandler = container.Resolve<IGameHandler>();

            _gameValidator.OnResultValidated.Subscribe((value) => _gameHandler.SwitchState(GameState.Debriefing));
        }
    }
}