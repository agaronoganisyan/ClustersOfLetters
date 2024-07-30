using System;
using UniRx;

namespace Infrastructure.UILogic.ViewModelLogic
{
    public abstract class CanvasViewModel
    {
        public IObservable<Unit> OnShown => _onShown;
        public IObservable<Unit> OnHidden => _onHidden;
        
        private readonly ReactiveCommand _onShown;
        private readonly ReactiveCommand _onHidden;

        public CanvasViewModel()
        {
            _onShown = new ReactiveCommand();
            _onHidden = new ReactiveCommand();
        }

        public virtual void Show()
        {
            _onShown?.Execute();
        }

        public virtual void Hide()
        {
            _onHidden?.Execute();
        }
    }
}