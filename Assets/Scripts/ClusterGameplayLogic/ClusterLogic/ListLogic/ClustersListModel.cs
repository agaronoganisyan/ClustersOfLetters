using System.Collections.Generic;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic.ListLogic
{
    public class ClustersListModel
    {
        public List<ClusterModel> Clusters { get; }
        
        public ClustersListModel()
        {
            Clusters = new List<ClusterModel>();
        }
        
        public void Setup(List<ClusterModel> clusters)
        {
            Clusters.Clear();
            for (int i = 0; i < clusters.Count; i++)
            {
                Clusters.Add(clusters[i]);
            }
        }
    }
}