using Cysharp.Threading.Tasks;

namespace ClusterGameplayLogic.InputFieldLogic.FactoryLogic
{
    public interface IInputFieldFactory
    {
        InputFieldView Get(InputFieldViewModel viewModel);
        UniTask Setup();
        void ReturnAllBack();
    }
}