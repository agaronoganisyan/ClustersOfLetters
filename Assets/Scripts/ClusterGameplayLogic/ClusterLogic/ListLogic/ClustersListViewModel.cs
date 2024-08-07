using ClusterGameplayLogic.ClusterLogic.ContainerLogic;
using UniRx;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic.ListLogic
{
    public class ClustersListViewModel : ClusterContainerViewModel
    {
        public ReactiveCommand<IReadOnlyReactiveCollection<ClusterViewModel>> OnSetuped;
        
        private ClustersListModel _clustersModel;
        
        public ClustersListViewModel(DiContainer container) : base(container)
        {
            _clustersModel = container.Resolve<ClustersListModel>();
            
            OnSetuped = new ReactiveCommand<IReadOnlyReactiveCollection<ClusterViewModel>>();
        }

        public void Setup()
        {
            _clusters.Clear();
            
            for (int i = 0; i < _clustersModel.Clusters.Count; i++)
            {
                ClusterViewModel viewModel = new ClusterViewModel(_clustersModel.Clusters[i], _container);
                _clusters.Add(viewModel);
                viewModel.SetInitClusterContainer(this);
            }

            OnSetuped?.Execute(_clusters);
        }

        public override bool IsCanAddCluster(ClusterViewModel clusterViewModel)
        {
            return true;
        }
    }
}