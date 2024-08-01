using Infrastructure.UILogic.DebriefingLogic.PanelLogic;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Infrastructure.UILogic.LobbyLogic.PanelLogic
{
    public class LobbyPanelView : MonoBehaviour
    {
        private LobbyPanelViewModel _viewModel;
        
        [Inject]
        public virtual void Construct(DiContainer container)
        {
            _viewModel = container.Resolve<LobbyPanelViewModel>();
        }
        
        public void OnStartMatch()
        {
            _viewModel.StartMatch();
        }
        
        public void OnOpenSettings()
        {
            _viewModel.OpenSettings();
        }
    }
}