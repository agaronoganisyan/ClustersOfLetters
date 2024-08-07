using System.Collections.Generic;
using ClusterGameplayLogic.InputFieldLogic;
using ClusterGameplayLogic.ValidatorLogic;
using Infrastructure.GameStateLogic;
using UniRx;
using Zenject;

namespace Infrastructure.UILogic.DebriefingLogic.PanelLogic
{
    public class DebriefingPanelViewModel
    {
        public ReactiveCommand<List<InputFieldModel>> OnDisplayFields { get; }
        
        private IGameStateMachine _gameStateMachine;
        private IGameValidator _gameValidator;
        
        private CompositeDisposable _disposable;

        public DebriefingPanelViewModel(DiContainer container)
        {
            OnDisplayFields = new ReactiveCommand<List<InputFieldModel>>();
            _disposable = new CompositeDisposable();
        }
        
        public void Setup(DiContainer container)
        {
            _gameStateMachine = container.Resolve<IGameStateMachine>();
            
            _gameValidator = container.Resolve<IGameValidator>();
            
            _gameValidator.OnResultValidated.
                Subscribe((value) => OnDisplayFields?.Execute(value)).AddTo(_disposable);

        }
        
        public void ToLobby()
        {
            _gameStateMachine.SwitchState(GameState.Lobby);
        }

        public List<InputFieldModel> GetFieldsForDisplay()
        {
            return _gameValidator.GetValidatedResult();
        }
    }
}