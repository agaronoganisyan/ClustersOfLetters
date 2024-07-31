using ClusterGameplayLogic.ClusterLogic;
using ClusterGameplayLogic.ClusterLogic.FactoryLogic;
using ClusterGameplayLogic.ClusterLogic.ListLogic;
using ClusterGameplayLogic.ClusterLogic.ProviderLogic;
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
        private IClustersViewFactory _clustersViewFactory;
        
        public Gameplay(IStateMachine<GameState> stateMachine, DiContainer container) : base(stateMachine,container)
        {
            _wordsProvider = container.Resolve<IWordsProvider>();
            _clustersProvider = container.Resolve<IClustersProvider>();
            _clustersListViewModel = container.Resolve<ClustersListViewModel>();
            _clustersViewFactory = container.Resolve<IClustersViewFactory>();
        }
        
        public override async UniTask Enter()
        {
            await _wordsProvider.Provide();
            await _clustersViewFactory.Setup();
            _clustersProvider.Provide();
            
            _clustersListViewModel.Setup();
            
            _uiStateMachine.SwitchState(UIState.Gameplay);
        }
    }
}