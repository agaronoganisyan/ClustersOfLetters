using UniRx;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic.ContainerLogic
{
    public abstract class ClusterContainerViewModel
    {
        public IReadOnlyReactiveCollection<ClusterViewModel> Clusters => _clusters;
        protected ReactiveCollection<ClusterViewModel> _clusters;
        
        public ReactiveCommand<IReadOnlyReactiveCollection<ClusterViewModel>> OnChanged;
        
        public ClusterContainerViewModel(DiContainer container)
        {
            _clusters = new ReactiveCollection<ClusterViewModel>();
            OnChanged = new ReactiveCommand<IReadOnlyReactiveCollection<ClusterViewModel>>();
        }

        public virtual void AddCluster(ClusterViewModel cluster)
        {
            _clusters.Add(cluster);
            OnChanged?.Execute(_clusters);
        }

        public virtual void RemoveCluster(ClusterViewModel cluster)
        {
            _clusters.Remove(cluster);
            OnChanged?.Execute(_clusters);
        }

        public abstract bool IsCanAddCluster(ClusterViewModel clusterViewModel);
    }
}