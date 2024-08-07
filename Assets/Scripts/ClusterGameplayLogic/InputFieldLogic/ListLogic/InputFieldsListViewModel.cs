using UniRx;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic.ListLogic
{
    public class InputFieldsListViewModel
    {
        public ReactiveCommand<IReadOnlyReactiveCollection<InputFieldViewModel>> OnSetuped;
        
        public IReadOnlyReactiveCollection<InputFieldViewModel> InputFields => _inputFields;
        private ReactiveCollection<InputFieldViewModel> _inputFields;

        private InputFieldsListModel _inputFieldsListModel;
        
        private bool _isSetuped;
        private DiContainer _container;

        private InputFieldsListViewModel(DiContainer container)
        {
            _container = container;
            _inputFieldsListModel = _container.Resolve<InputFieldsListModel>();
            
            _inputFields = new ReactiveCollection<InputFieldViewModel>();
            OnSetuped = new ReactiveCommand<IReadOnlyReactiveCollection<InputFieldViewModel>>();
        }

        public void Setup()
        {
            if (_isSetuped)
            {
                for (int i = 0; i < _inputFields.Count; i++)
                {
                    _inputFields[i].Cleanup();
                }
            }
            else
            {
                _inputFields.Clear();
            
                for (int i = 0; i < _inputFieldsListModel.InputFields.Count; i++)
                {
                    _inputFields.Add(new InputFieldViewModel(_inputFieldsListModel.InputFields[i], _container));
                }
            
                OnSetuped?.Execute(_inputFields);

                SetAsSetuped();   
            }
        }
        
        private void SetAsSetuped()
        {
            _isSetuped = true;
        }
    }
}