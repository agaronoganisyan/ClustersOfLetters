using ClusterGameplayLogic.ClusterLogic.ContainerLogic;
using UniRx;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic.ListLogic
{
    public class ClustersListViewModel : ClusterContainerViewModel
    {
        public ReactiveCommand<IReadOnlyReactiveCollection<ClusterViewModel>> OnSetuped;
        
        private ClustersModel _clustersModel;
        
        public ClustersListViewModel(DiContainer container) : base(container)
        {
            _clustersModel = container.Resolve<ClustersModel>();
            
            OnSetuped = new ReactiveCommand<IReadOnlyReactiveCollection<ClusterViewModel>>();
        }

        public void Setup()
        {
            _clusters.Clear();
            
            for (int i = 0; i < _clustersModel.Clusters.Count; i++)
            {
                _clusters.Add(_clustersModel.Clusters[i]);
                _clustersModel.Clusters[i].SetInitClusterContainer(this);
            }
        }

        public override bool TryToAddCluster(ClusterViewModel clusterViewModel)
        {
            return true;
        }
    }
}