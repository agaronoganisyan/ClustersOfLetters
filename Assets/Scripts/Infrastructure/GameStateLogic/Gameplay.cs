using ClusterGameplayLogic.ClusterLogic.FactoryLogic;
using ClusterGameplayLogic.ClusterLogic.ListLogic;
using ClusterGameplayLogic.ClusterLogic.ProviderLogic;
using ClusterGameplayLogic.InputFieldLogic.FactoryLogic;
using ClusterGameplayLogic.InputFieldLogic.ListLogic;
using ClusterGameplayLogic.InputFieldLogic.ProviderLogic;
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
        private IClustersProvider _clustersProvider;
        private ClustersListViewModel _clustersListViewModel;
        private InputFieldsListViewModel _inputFieldsListViewModel;
        private IInputFieldFactory _inputFieldFactory;
        private IInputFieldsProvider _inputFieldsProvider;
        private IClustersViewFactory _clustersViewFactory;

        public Gameplay(IStateMachine<GameState> stateMachine, DiContainer container) : base(stateMachine,container)
        {
            _wordsProvider = container.Resolve<IWordsProvider>();
            _clustersProvider = container.Resolve<IClustersProvider>();
            _clustersListViewModel = container.Resolve<ClustersListViewModel>();
            _clustersViewFactory = container.Resolve<IClustersViewFactory>();
            _inputFieldsListViewModel = container.Resolve<InputFieldsListViewModel>();
            _inputFieldFactory = container.Resolve<IInputFieldFactory>();
            _inputFieldsProvider = container.Resolve<IInputFieldsProvider>();
        }
        
        public override async UniTask Enter()
        {
            await _wordsProvider.Provide();
            await _inputFieldFactory.Setup();
            await _clustersViewFactory.Setup();
            _inputFieldsProvider.Provide();
            _clustersProvider.Provide();

            _inputFieldsListViewModel.Setup();
            _clustersListViewModel.Setup();
            
            _uiStateMachine.SwitchState(UIState.Gameplay);
        }
    }
}