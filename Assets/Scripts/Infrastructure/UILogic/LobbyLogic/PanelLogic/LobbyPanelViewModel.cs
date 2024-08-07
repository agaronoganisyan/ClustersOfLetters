using Infrastructure.GameHandlerLogic;
using Infrastructure.GameStateLogic;
using Infrastructure.UILogic.LobbyLogic.SettingsLogic;
using Zenject;

namespace Infrastructure.UILogic.LobbyLogic.PanelLogic
{
    public class LobbyPanelViewModel
    {
        private SettingsPanelViewModel _settingsPanelViewModel;
        protected IGameHandler _gameHandler;
        
        public LobbyPanelViewModel(DiContainer container)
        {
            _gameHandler = container.Resolve<IGameHandler>();
            
            _settingsPanelViewModel = container.Resolve<SettingsPanelViewModel>();
        }
        
        public void StartMatch()
        {
            _gameHandler.SwitchState(GameState.Gameplay);
        }
        
        public void OpenSettings()
        {
            _settingsPanelViewModel.Show();
        }
    }
}