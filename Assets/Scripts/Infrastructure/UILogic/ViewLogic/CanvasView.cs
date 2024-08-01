using System;
using Infrastructure.GameStateLogic;
using Infrastructure.UILogic.ViewModelLogic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Infrastructure.UILogic.ViewLogic
{
    public abstract class CanvasView : MonoBehaviour, IDisposable
    {
        public Canvas Canvas => _canvas;
        private Canvas _canvas;
        private GraphicRaycaster _graphicRaycaster;

        protected CanvasViewModel _viewModel;
        
        private CompositeDisposable _disposable;
        
        [Inject]
        public virtual void Construct(DiContainer container)
        {
            _disposable = new CompositeDisposable();
        }
        
        protected virtual void Awake()
        {
            _canvas = gameObject.GetComponent<Canvas>();
            _graphicRaycaster = gameObject.GetComponent<GraphicRaycaster>();
            
            _viewModel.OnShown.Subscribe((value) => Show()).AddTo(_disposable);
            _viewModel.OnHidden.Subscribe((value) => Hide()).AddTo(_disposable);
        }

        protected virtual void Show()
        {
            _canvas.enabled = true;
            _graphicRaycaster.enabled = true;
        }

        private void Hide()
        {
            _canvas.enabled = false;
            _graphicRaycaster.enabled = false;
        }
        
        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}