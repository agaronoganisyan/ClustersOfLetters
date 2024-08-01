using System.Collections.Generic;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic
{
    public class ClustersModel
    {
        public List<ClusterViewModel> Clusters { get; }

        private DiContainer _container;
        
        public ClustersModel(DiContainer container)
        {
            _container = container;
            
            Clusters = new List<ClusterViewModel>();
        }
        
        public void Setup(List<ClusterModel> clusters)
        {
            Clusters.Clear();
            for (int i = 0; i < clusters.Count; i++)
            {
                Clusters.Add(new ClusterViewModel(clusters[i], _container));
            }
        }
    }
}