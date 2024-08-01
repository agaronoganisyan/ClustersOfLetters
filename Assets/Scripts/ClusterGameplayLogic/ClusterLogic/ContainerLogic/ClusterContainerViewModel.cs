using UniRx;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic.ContainerLogic
{
    public abstract class ClusterContainerViewModel
    {
        protected DiContainer _container;
        
        public IReadOnlyReactiveCollection<ClusterViewModel> Clusters => _clusters;
        protected ReactiveCollection<ClusterViewModel> _clusters;
        
        public ClusterContainerViewModel(DiContainer container)
        {
            _container = container;
            
            _clusters = new ReactiveCollection<ClusterViewModel>();
        }

        public virtual void AddCluster(ClusterViewModel cluster)
        {
            _clusters.Add(cluster);
        }

        public virtual void RemoveCluster(ClusterViewModel cluster)
        {
            _clusters.Remove(cluster);
        }

        public abstract bool TryToAddCluster(ClusterViewModel clusterViewModel);
    }
}