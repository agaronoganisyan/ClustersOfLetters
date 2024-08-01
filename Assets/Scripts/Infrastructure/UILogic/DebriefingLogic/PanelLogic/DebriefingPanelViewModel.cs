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
        public ReactiveCommand<List<InputFieldViewModel>> OnDisplayFields { get; }
        
        private IGameStateMachine _gameStateMachine;
        private IGameValidator _gameValidator;
        
        private CompositeDisposable _disposable;

        public DebriefingPanelViewModel(DiContainer container)
        {
            OnDisplayFields = new ReactiveCommand<List<InputFieldViewModel>>();
            _disposable = new CompositeDisposable();
        }
        
        public void Setup(DiContainer container)
        {
            _gameStateMachine = container.Resolve<IGameStateMachine>();
            
            _gameValidator= container.Resolve<IGameValidator>();
            
            _gameValidator.OnResultValidated.
                Subscribe((value) => OnDisplayFields?.Execute(value)).AddTo(_disposable);

        }
        
        public void ToLobby()
        {
            _gameStateMachine.SwitchState(GameState.Lobby);
        }

        public List<InputFieldViewModel> GetFieldsForDisplay()
        {
            return _gameValidator.GetValidatedResult();
        }
    }
}