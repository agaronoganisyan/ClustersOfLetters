using ClusterGameplayLogic.LevelLogic.StateLogic;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic.ListLogic.ProviderLogic
{
    public class InputFieldsListProvider : IInputFieldsListProvider
    {
        private InputFieldsListModel _inputFieldsListModel;
        private LevelStateModel _levelStateModel;
        
        public InputFieldsListProvider(DiContainer container)
        {
            _inputFieldsListModel = container.Resolve<InputFieldsListModel>();
            _levelStateModel = container.Resolve<LevelStateModel>();
        }

        public void Provide()
        {
            _inputFieldsListModel.Setup(_levelStateModel.InputFields);
        }
    }
}