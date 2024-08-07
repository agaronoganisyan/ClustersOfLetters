using ClusterGameplayLogic.LevelLogic.StateLogic;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic.ListLogic.ProviderLogic
{
    public class ClustersListProvider : IClustersListProvider
    {
        private ClustersListModel _clustersListModel;
        private LevelStateModel _levelStateModel;

        public ClustersListProvider(DiContainer container)
        {
            _clustersListModel = container.Resolve<ClustersListModel>();
            _levelStateModel = container.Resolve<LevelStateModel>();
        }

        public void Provide()
        {
            _clustersListModel.Setup(_levelStateModel.ClustersList);
        }
    }
}