using ClusterGameplayLogic.ClusterLogic.GeneratorLogic;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic.ProviderLogic
{
    public class ClustersProvider : IClustersProvider
    {
        private ClustersModel _clustersModel;
        private IClustersGenerator _generator;
        
        public ClustersProvider(DiContainer container)
        {
            _clustersModel = container.Resolve<ClustersModel>();
            _generator = container.Resolve<IClustersGenerator>();
        }

        public void Provide()
        {
            _clustersModel.Setup(_generator.GenerateRandomClusters());
        }
    }
}