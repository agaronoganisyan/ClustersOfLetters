using Infrastructure.UILogic.ViewLogic;
using Zenject;

namespace Infrastructure.UILogic.DebriefingLogic
{
    public class DebriefingCanvasView : CanvasView
    {
        public override void Construct(DiContainer container)
        {
            base.Construct(container);
            
            _viewModel = container.Resolve<DebriefingCanvasViewModel>();
            _viewModel.SetView(this);
        }
    }
}