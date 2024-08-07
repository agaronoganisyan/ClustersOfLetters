using ClusterGameplayLogic.ClusterLogic;

namespace ClusterGameplayLogic.InputFieldLogic.CellLogic
{
    public class CellModel
    {
        public ClusterModel ClusterModel { get; private set; }

        public void AddCluster(ClusterModel model)
        {
            ClusterModel = model;
        }

        public void RemoveCluster()
        {
            ClusterModel = null;
        }
        
        public void Cleanup()
        {
            ClusterModel = null;
        }
    }
}