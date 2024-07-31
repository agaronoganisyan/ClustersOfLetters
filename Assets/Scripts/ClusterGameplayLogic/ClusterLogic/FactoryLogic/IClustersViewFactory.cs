using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace ClusterGameplayLogic.ClusterLogic.FactoryLogic
{
    public interface IClustersViewFactory
    {
        ClusterView Get(ClusterViewModel viewModel);
        UniTask Setup();
    }
}