using UniRx;
using UnityEngine;
using Zenject;

namespace Infrastructure.UILogic.LobbyLogic.SettingsLogic
{
    public class SettingsPanelView : MonoBehaviour
    {
        private SettingsPanelViewModel _viewModel;
        private CompositeDisposable _disposable;

        [Inject]
        public virtual void Construct(DiContainer container)
        {
            _viewModel = container.Resolve<SettingsPanelViewModel>();
            
            _disposable = new CompositeDisposable();
        }
        
        private void Start()
        {
            _viewModel.OnShown.Subscribe((value) => Show()).AddTo(_disposable);
            _viewModel.OnHidden.Subscribe((value) => Hide()).AddTo(_disposable);
            
            gameObject.SetActive(false);
        }

        public void OnClose()
        {
            _viewModel.Hide();
        }
        
        private void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}