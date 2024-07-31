using ClusterGameplayLogic.ClusterLogic.GeneratorLogic;
using ClusterGameplayLogic.WordLogic;
using Cysharp.Threading.Tasks;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic.ProviderLogic
{
    public class ClustersProvider : IClustersProvider
    {
        private WordsModel _wordsModel;
        private ClustersModel _clustersModel;
        private IClustersGenerator _generator;
        
        public ClustersProvider(DiContainer container)
        {
            _wordsModel = container.Resolve<WordsModel>();
            _clustersModel = container.Resolve<ClustersModel>();
            _generator = container.Resolve<IClustersGenerator>();
        }

        public void Provide()
        {
            _clustersModel.Setup(_generator.GenerateRandomClusters());
        }
    }
}