using System.Collections.Generic;
using ClusterGameplayLogic.InputFieldLogic;
using ClusterGameplayLogic.ValidatorLogic;
using Infrastructure.GameHandlerLogic;
using Infrastructure.GameStateLogic;
using UniRx;
using Zenject;

namespace Infrastructure.UILogic.DebriefingLogic.PanelLogic
{
    public class DebriefingPanelViewModel
    {
        public ReactiveCommand<List<InputFieldModel>> OnDisplayFields { get; }
        
        private IGameHandler _gameHandler;
        private IGameValidator _gameValidator;
        
        private CompositeDisposable _disposable;

        public DebriefingPanelViewModel(DiContainer container)
        {
            _gameHandler = container.Resolve<IGameHandler>();
            
            _gameValidator = container.Resolve<IGameValidator>();

            _disposable = new CompositeDisposable();
            OnDisplayFields = new ReactiveCommand<List<InputFieldModel>>();
    
            _gameValidator.OnResultValidated.
                Subscribe((value) => OnDisplayFields?.Execute(value)).AddTo(_disposable);
        }
        
        public void ToLobby()
        {
            _gameHandler.SwitchState(GameState.Lobby);
        }

        public List<InputFieldModel> GetFieldsForDisplay()
        {
            return _gameValidator.GetValidatedResult();
        }
    }
}