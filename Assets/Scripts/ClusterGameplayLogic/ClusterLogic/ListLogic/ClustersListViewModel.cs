using UniRx;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic.ListLogic
{
    public class ClustersListViewModel
    {
        public IReadOnlyReactiveCollection<ClusterViewModel> Clusters => _clusters;
        private ReactiveCollection<ClusterViewModel> _clusters;

        public ReactiveCommand<IReadOnlyReactiveCollection<ClusterViewModel>> OnSetuped;
        
        private ClustersModel _clustersModel;
        
        public ClustersListViewModel(DiContainer container)
        {
            _clustersModel = container.Resolve<ClustersModel>();
            
            _clusters = new ReactiveCollection<ClusterViewModel>();
            OnSetuped = new ReactiveCommand<IReadOnlyReactiveCollection<ClusterViewModel>>();
        }

        public void Setup()
        {
            _clusters.Clear();
            
            for (int i = 0; i < _clustersModel.Clusters.Count; i++)
            {
                _clusters.Add(new ClusterViewModel(_clustersModel.Clusters[i]));
            }
        }

        public void RemoveCluster(ClusterViewModel cluster)
        {
            
        }

        public void AddCluster(ClusterViewModel cluster)
        {
            
        }
    }
}