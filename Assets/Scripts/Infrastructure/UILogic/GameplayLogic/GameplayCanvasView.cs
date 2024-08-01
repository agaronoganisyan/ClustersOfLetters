using Infrastructure.UILogic.ViewLogic;
using Zenject;

namespace Infrastructure.UILogic.GameplayLogic
{
    public class GameplayCanvasView : CanvasView
    {
        public override void Construct(DiContainer container)
        {
            base.Construct(container);
            
            _viewModel = container.Resolve<GameplayCanvasViewModel>();
            _viewModel.SetView(this);
        }
    }
}