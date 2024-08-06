using System.Collections.Generic;
using System.Text;
using ClusterGameplayLogic.ClusterLogic;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic
{
    public class InputFieldModel
    {
        public List<ClusterModel> Clusters { get; }
        
        public InputFieldModel()
        {
            Clusters = new List<ClusterModel>();
        }
        
        public void Setup(List<ClusterModel> clusters = null)
        {
            Clusters.Clear();

            if (clusters != null)
            {
                for (int i = 0; i < clusters.Count; i++)
                {
                    AddCluster(clusters[i]);
                }
            }
        }

        public void AddCluster(ClusterModel cluster)
        {
            Clusters.Add(cluster);
        }

        public void RemoveCluster(ClusterModel cluster)
        {
            Clusters.Remove(cluster);
        }

        public void Cleanup()
        {
            Clusters.Clear();
        }
        
        public string GetWord()
        {
            StringBuilder wordBuilder = new StringBuilder();

            foreach (var cluster in Clusters)
            {
                wordBuilder.Append(cluster.Value);
            }

            return wordBuilder.ToString();
        }
    }
}