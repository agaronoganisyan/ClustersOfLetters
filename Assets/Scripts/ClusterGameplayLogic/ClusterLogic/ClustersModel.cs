using System.Collections.Generic;

namespace ClusterGameplayLogic.ClusterLogic
{
    public class ClustersModel
    {
        public List<ClusterModel> Clusters { get; }

        public ClustersModel()
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