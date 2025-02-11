using System;

namespace ClusterGameplayLogic.ClusterLogic
{
    [Serializable]
    public class ClusterModel
    {
        public string Value { get; }
        public int Length { get; }

        public ClusterModel(string value, int length)
        {
            Value = value;
            Length = length;
        }
    }
}