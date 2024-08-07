using System.Collections.Generic;
using System.Text;
using ClusterGameplayLogic.ClusterLogic;
using ClusterGameplayLogic.InputFieldLogic.CellLogic;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic
{
    public class InputFieldModel
    {
        public List<ClusterModel> Clusters { get; }
        public Dictionary<int, CellModel> Cells { get; }

        public InputFieldModel()
        {
            Clusters = new List<ClusterModel>();
            Cells = new Dictionary<int, CellModel>();
            for (int i = 0; i < InputFieldStaticData.BaseLength; i++)
            {
                Cells.Add(i, new CellModel());
            }
        }
        
        public void Setup(List<ClusterModel> clusters = null)
        {
            Clusters.Clear();
            Cells.Clear();
            
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

        public bool IsCanAddCluster()
        {
            bool status = false;


            return status;
        }

        public void Cleanup()
        {
            Clusters.Clear();
            for (int i = 0; i < Cells.Count; i++)
            {
                Cells[i].Cleanup();
            }
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