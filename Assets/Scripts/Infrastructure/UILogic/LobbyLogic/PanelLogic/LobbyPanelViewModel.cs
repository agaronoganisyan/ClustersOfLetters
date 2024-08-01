using Infrastructure.GameStateLogic;
using Infrastructure.UILogic.LobbyLogic.SettingsLogic;
using Zenject;

namespace Infrastructure.UILogic.LobbyLogic.PanelLogic
{
    public class LobbyPanelViewModel
    {
        private SettingsPanelViewModel _settingsPanelViewModel;
        protected IGameStateMachine _gameStateMachine;
        
        public void Setup(DiContainer container)
        {
            _gameStateMachine = container.Resolve<IGameStateMachine>();
            
            _settingsPanelViewModel = container.Resolve<SettingsPanelViewModel>();
        }
        
        public void StartMatch()
        {
            _gameStateMachine.SwitchState(GameState.Gameplay);
        }
        
        public void OpenSettings()
        {
            _settingsPanelViewModel.Show();
        }
    }
}