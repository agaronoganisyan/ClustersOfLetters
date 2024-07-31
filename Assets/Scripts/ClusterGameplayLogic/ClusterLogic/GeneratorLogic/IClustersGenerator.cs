using System.Collections.Generic;
using UniRx;

namespace ClusterGameplayLogic.ClusterLogic.GeneratorLogic
{
    public interface IClustersGenerator
    {
        List<ClusterModel> GenerateRandomClusters();
    }
}