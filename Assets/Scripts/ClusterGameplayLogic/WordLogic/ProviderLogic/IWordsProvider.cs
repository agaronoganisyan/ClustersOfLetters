using Cysharp.Threading.Tasks;

namespace ClusterGameplayLogic.WordLogic.ProviderLogic
{
    public interface IWordsProvider
    {
        UniTask Provide();
    }
}