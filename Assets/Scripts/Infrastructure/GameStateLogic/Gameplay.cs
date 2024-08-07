using ClusterGameplayLogic.ClusterLogic.FactoryLogic;
using ClusterGameplayLogic.ClusterLogic.ListLogic;
using ClusterGameplayLogic.ClusterLogic.ListLogic.ProviderLogic;
using ClusterGameplayLogic.InputFieldLogic.FactoryLogic;
using ClusterGameplayLogic.InputFieldLogic.ListLogic;
using ClusterGameplayLogic.InputFieldLogic.ListLogic.ProviderLogic;
using ClusterGameplayLogic.LevelLogic.StateLogic.ProviderLogic;
using ClusterGameplayLogic.WordLogic.ProviderLogic;
using Cysharp.Threading.Tasks;
using Infrastructure.StateMachineLogic;
using Infrastructure.UILogic.UIStateMachineLogic;
using Zenject;

namespace Infrastructure.GameStateLogic
{
    public class Gameplay : GameBaseState<GameState>
    {
        private IWordsProvider _wordsProvider;        
        private ClustersListViewModel _clustersListViewModel;
        private InputFieldsListViewModel _inputFieldsListViewModel;
        private IInputFieldFactory _inputFieldFactory;
        private IInputFieldsListProvider _inputFieldsListProvider;
        private IClustersListProvider _clustersListProvider;
        private IClustersViewFactory _clustersViewFactory;
        private ILevelStateProvider _levelStateProvider;

        public Gameplay(IStateMachine<GameState> stateMachine, DiContainer container) : base(stateMachine,container)
        {
            _wordsProvider = container.Resolve<IWordsProvider>();
            _clustersListViewModel = container.Resolve<ClustersListViewModel>();
            _clustersViewFactory = container.Resolve<IClustersViewFactory>();
            _inputFieldsListViewModel = container.Resolve<InputFieldsListViewModel>();
            _inputFieldFactory = container.Resolve<IInputFieldFactory>();
            _inputFieldsListProvider = container.Resolve<IInputFieldsListProvider>();
            _levelStateProvider = container.Resolve<ILevelStateProvider>();
            _clustersListProvider = container.Resolve<IClustersListProvider>();
        }
        
        public override async UniTask Enter()
        {
            await _wordsProvider.Provide();
            await _inputFieldFactory.Setup();
            await _clustersViewFactory.Setup();
            
            _levelStateProvider.Provide();
            _clustersListProvider.Provide();
            _inputFieldsListProvider.Provide();

            _inputFieldsListViewModel.Setup();
            _clustersListViewModel.Setup();
            
            _uiStateMachine.SwitchState(UIState.Gameplay);
        }

        public override async UniTask Exit()
        {
            _clustersViewFactory.ReturnAllBack();
        }
    }
}