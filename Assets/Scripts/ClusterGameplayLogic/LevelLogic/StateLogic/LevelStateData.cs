using System.Collections.Generic;
using ClusterGameplayLogic.ClusterLogic;
using ClusterGameplayLogic.InputFieldLogic;

namespace ClusterGameplayLogic.LevelLogic.StateLogic
{
    [System.Serializable]
    public class LevelStateData
    {
        public List<InputFieldModel> InputFields = new List<InputFieldModel>();
        public List<ClusterModel> ClustersList = new List<ClusterModel>();

        public void Setup(List<ClusterModel> clustersList, List<InputFieldModel> inputFields = null)
        {
            ClustersList = clustersList;
            InputFields = inputFields;
        }

        public void Remove()
        {
            InputFields.Clear();
            ClustersList.Clear();
        }
    }
}