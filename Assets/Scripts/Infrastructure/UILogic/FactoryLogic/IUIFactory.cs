using Cysharp.Threading.Tasks;
using Infrastructure.UILogic.UIStateMachineLogic;
using Infrastructure.UILogic.ViewLogic;

namespace Infrastructure.UILogic.FactoryLogic
{
    public interface IUIFactory
    {
        UniTask<CanvasView> GetCanvas(UIState canvasType);
    }
}