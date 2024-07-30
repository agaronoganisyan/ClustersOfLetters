using System;
using Cysharp.Threading.Tasks;
using Infrastructure.StateMachineLogic;
using Infrastructure.StateMachineLogic.Async;
using Infrastructure.UILogic.FactoryLogic;
using Infrastructure.UILogic.ViewLogic;
using Infrastructure.UILogic.ViewModelLogic;
using UnityEngine;
using Zenject;

namespace Infrastructure.UILogic.UIStateMachineLogic
{
    public enum UIState
    {
        None,
        Lobby,
        Gameplay,
        Debriefing
    }

    public class UIBaseState<State> : IAsyncState<State> where State : Enum
    {
        public State StateKey => _stateKey;
        private State _stateKey;
        
        protected readonly IStateMachine<UIState> _stateMachine;

        protected IUIFactory _uiFactory;
        protected CanvasViewModel _viewModel;
        protected CanvasView _view;

        private bool _isViewLoaded;
        
        protected UIBaseState(State state, IStateMachine<UIState> stateMachine, DiContainer container)
        {
            _stateKey = state;
            _stateMachine = stateMachine;
            _uiFactory = container.Resolve<IUIFactory>();
        }

        public virtual async UniTask Enter()
        {
            if (!_isViewLoaded) await LoadView();
            
            _viewModel.Show();
        }

        public virtual async UniTask Exit()
        {
            _viewModel.Hide();
        }

        public virtual void Update()
        {
            
        }
        
        private async UniTask LoadView()
        {
            _view = await _uiFactory.GetCanvas((UIState)(object)_stateKey);
            _isViewLoaded = true;
        }
    }
}