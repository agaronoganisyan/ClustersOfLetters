using ClusterGameplayLogic.ClusterLogic;
using ClusterGameplayLogic.ClusterLogic.FactoryLogic;
using ClusterGameplayLogic.ClusterLogic.GeneratorLogic;
using ClusterGameplayLogic.ClusterLogic.ListLogic;
using ClusterGameplayLogic.ClusterLogic.ProviderLogic;
using ClusterGameplayLogic.WordLogic;
using ClusterGameplayLogic.WordLogic.ProviderLogic;
using Infrastructure.AssetManagementLogic;
using Infrastructure.GameStateLogic;
using Infrastructure.PoolLogic;
using Infrastructure.UILogic.FactoryLogic;
using Infrastructure.UILogic.UIStateMachineLogic;
using Infrastructure.UILogic.ViewModelLogic;
using Zenject;

namespace Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAssetsProvider>().To<AssetsProvider>().FromNew().AsSingle();
            
            Container.Bind<IUIFactory>().To<UIFactory>().FromNew().AsSingle();
            Container.Bind<IClustersViewFactory>().To<ClustersViewFactory>().FromNew().AsSingle();
            Container.Bind<ClustersListViewModel>().FromNew().AsSingle();
            
            Container.Bind<ObjectPool<ClusterView>>().FromNew().AsTransient();
            Container.Bind<ClusterViewFactory<ClusterView>>().FromNew().AsTransient();
            
            Container.Bind<IWordsProvider>().To<WordsProvider>().FromNew().AsSingle();
            Container.Bind<IClustersProvider>().To<ClustersProvider>().FromNew().AsSingle();
            Container.Bind<IClustersGenerator>().To<ClustersGenerator>().FromNew().AsSingle();

            Container.Bind<WordsModel>().FromNew().AsSingle();
            Container.Bind<ClustersModel>().FromNew().AsSingle();

            Container.Bind<IGameStateMachine>().To<GameStateMachine>().FromNew().AsSingle();
            Container.Bind<IUIStateMachine>().To<UIStateMachine>().FromNew().AsSingle();
            
            Container.Bind<LobbyViewModel>().FromNew().AsSingle();
            Container.Bind<MatchViewModel>().FromNew().AsSingle();
            Container.Bind<DebriefingViewModel>().FromNew().AsSingle();
        }
    }
}
