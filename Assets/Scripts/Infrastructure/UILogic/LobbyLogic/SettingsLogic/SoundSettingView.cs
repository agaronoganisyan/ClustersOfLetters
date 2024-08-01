using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Infrastructure.UILogic.LobbyLogic.SettingsLogic
{
    public class SoundSettingView : MonoBehaviour
    {
        private SettingsPanelViewModel _viewModel;

        private Toggle _toggle;
        
        private CompositeDisposable _disposable;
        
        [Inject]
        public virtual void Construct(DiContainer container)
        {
            _viewModel = container.Resolve<SettingsPanelViewModel>();

            _toggle = GetComponent<Toggle>();
            
            _disposable = new CompositeDisposable();
        }

        private void Start()
        {
            _toggle.onValueChanged.AsObservable().Subscribe(_viewModel.SetSoundSettings).AddTo(_disposable);
        }
    }
}