using UniRx;
using Unity.VisualScripting;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic.ListLogic
{
    public class InputFieldsListViewModel
    {
        public ReactiveCommand<IReadOnlyReactiveCollection<InputFieldViewModel>> OnSetuped;
        
        public IReadOnlyReactiveCollection<InputFieldViewModel> InputFields => _inputFields;
        private ReactiveCollection<InputFieldViewModel> _inputFields;

        private InputFieldsModel _inputFieldsModel;
        
        private InputFieldsListViewModel(DiContainer container)
        {
            _inputFieldsModel = container.Resolve<InputFieldsModel>();
            
            _inputFields = new ReactiveCollection<InputFieldViewModel>();

            OnSetuped = new ReactiveCommand<IReadOnlyReactiveCollection<InputFieldViewModel>>();
        }

        public void Setup()
        {
            _inputFields.Clear();
            
            for (int i = 0; i < _inputFieldsModel.InputFields.Count; i++)
            {
                _inputFields.Add(_inputFieldsModel.InputFields[i]);
            }
            
            OnSetuped?.Execute(_inputFields);
        }
    }
}