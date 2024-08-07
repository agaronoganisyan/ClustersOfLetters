using System.Collections.Generic;
using ClusterGameplayLogic.ClusterLogic;
using ClusterGameplayLogic.InputFieldLogic;

namespace ClusterGameplayLogic.LevelLogic.StateLogic
{
    public class LevelStateModel
    {
        public List<InputFieldModel> InputFields { get; }
        public List<ClusterModel> ClustersList { get; }

        public LevelStateModel()
        {
            InputFields = new List<InputFieldModel>();
            ClustersList = new List<ClusterModel>();
        }

        public void Setup(List<ClusterModel> clustersList, List<InputFieldModel> inputFields = null)
        {
            ClustersList.Clear();
            
            if (clustersList.Count > 0)
            {
                for (int i = 0; i < clustersList.Count; i++)
                {
                    ClustersList.Add(clustersList[i]);
                }
            }
            
            if (inputFields != null && inputFields.Count > 0)
            {
                InputFields.Clear();
                
                for (int i = 0; i < inputFields.Count; i++)
                {
                    InputFields.Add(inputFields[i]);
                }
            }
        }
    }
}