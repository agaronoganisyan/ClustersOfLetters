using ClusterGameplayLogic.ClusterLogic;
using ClusterGameplayLogic.ClusterLogic.FactoryLogic;
using ClusterGameplayLogic.ClusterLogic.GeneratorLogic;
using ClusterGameplayLogic.ClusterLogic.ListLogic;
using ClusterGameplayLogic.ClusterLogic.ProviderLogic;
using ClusterGameplayLogic.InputFieldLogic;
using ClusterGameplayLogic.InputFieldLogic.FactoryLogic;
using ClusterGameplayLogic.InputFieldLogic.ListLogic;
using ClusterGameplayLogic.InputFieldLogic.ProviderLogic;
using ClusterGameplayLogic.ValidatorLogic;
using ClusterGameplayLogic.WordLogic;
using ClusterGameplayLogic.WordLogic.ProviderLogic;
using Infrastructure.AssetManagementLogic;
using Infrastructure.GameStateLogic;
using Infrastructure.PoolLogic;
using Infrastructure.UILogic.DebriefingLogic;
using Infrastructure.UILogic.DebriefingLogic.PanelLogic;
using Infrastructure.UILogic.FactoryLogic;
using Infrastructure.UILogic.GameplayLogic;
using Infrastructure.UILogic.LobbyLogic;
using Infrastructure.UILogic.LobbyLogic.PanelLogic;
using Infrastructure.UILogic.LobbyLogic.SettingsLogic;
using Infrastructure.UILogic.UIStateMachineLogic;
using Zenject;

namespace Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //General
            Container.Bind<IAssetsProvider>().To<AssetsProvider>().FromNew().AsSingle();
            Container.Bind<IGameValidator>().To<GameValidator>().FromNew().AsSingle();
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().FromNew().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().FromNew().AsSingle();
            Container.Bind<IUIStateMachine>().To<UIStateMachine>().FromNew().AsSingle();
            
            //Word
            Container.Bind<IWordsProvider>().To<WordsProvider>().FromNew().AsSingle();
            Container.Bind<WordsModel>().FromNew().AsSingle();
            
            //Cluster
            Container.Bind<IClustersViewFactory>().To<ClustersViewFactory>().FromNew().AsSingle();
            Container.Bind<ClustersListViewModel>().FromNew().AsSingle();
            Container.Bind<ObjectPool<ClusterView>>().FromNew().AsTransient();
            Container.Bind<ClusterViewFactory<ClusterView>>().FromNew().AsTransient();
            Container.Bind<IClustersProvider>().To<ClustersProvider>().FromNew().AsSingle();
            Container.Bind<IClustersGenerator>().To<ClustersGenerator>().FromNew().AsSingle();
            Container.Bind<ClustersModel>().FromNew().AsSingle();

            //InputField
            Container.Bind<InputFieldViewModel>().FromNew().AsTransient();
            Container.Bind<ObjectPool<InputFieldView>>().FromNew().AsTransient();
            Container.Bind<InputFieldViewFactory<InputFieldView>>().FromNew().AsTransient();
            Container.Bind<InputFieldsModel>().FromNew().AsSingle();
            Container.Bind<IInputFieldFactory>().To<InputFieldFactory>().FromNew().AsSingle();
            Container.Bind<IInputFieldsProvider>().To<InputFieldsProvider>().FromNew().AsSingle();
            Container.Bind<InputFieldsListViewModel>().FromNew().AsSingle();
            
            //Canvases
            Container.Bind<LobbyCanvasViewModel>().FromNew().AsSingle();
            Container.Bind<GameplayCanvasViewModel>().FromNew().AsSingle();
            Container.Bind<DebriefingCanvasViewModel>().FromNew().AsSingle();
            
            //CanvasPanels
            Container.Bind<LobbyPanelViewModel>().FromNew().AsSingle();
            Container.Bind<DebriefingPanelViewModel>().FromNew().AsSingle();
            Container.Bind<SettingsPanelViewModel>().FromNew().AsSingle();
        }
    }
}
