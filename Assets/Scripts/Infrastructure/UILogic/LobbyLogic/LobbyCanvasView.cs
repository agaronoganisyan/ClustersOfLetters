using Infrastructure.GameStateLogic;
using Infrastructure.UILogic.ViewLogic;
using Zenject;

namespace Infrastructure.UILogic.LobbyLogic
{
    public class LobbyCanvasView : CanvasView
    {
        public override void Construct(DiContainer container)
        {
            base.Construct(container);
            
            _viewModel = container.Resolve<LobbyCanvasViewModel>();
            _viewModel.SetView(this);
        }
    }
}