using System;
using UniRx;
using UnityEngine;

namespace Infrastructure.UILogic.LobbyLogic.SettingsLogic
{
    public class SettingsPanelViewModel
    {
        public IObservable<Unit> OnShown => _onShown;
        public IObservable<Unit> OnHidden => _onHidden;
        
        private readonly ReactiveCommand _onShown;
        private readonly ReactiveCommand _onHidden;

        public SettingsPanelViewModel()
        {
            _onShown = new ReactiveCommand();
            _onHidden = new ReactiveCommand();
        }

        public void SetSoundSettings(bool status)
        {
            if (status) Debug.Log("SOUND ENABLED");
            else Debug.Log("SOUND DISABLED");
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