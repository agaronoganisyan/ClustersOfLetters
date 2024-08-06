using System.Collections.Generic;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic
{
    public class InputFieldsModel
    {
        private readonly DiContainer _container;
        public List<InputFieldViewModel> InputFields { get; }

        private const int BaseNumberOfInputFields = 4;
        
        private bool _isSetuped;
        
        public InputFieldsModel(DiContainer container)
        {
            _container = container;
            
            InputFields = new List<InputFieldViewModel>();
        }
        
        public void Setup(List<InputFieldModel> inputFields = null)
        {
            if (_isSetuped)
            {
                for (int i = 0; i < InputFields.Count; i++)
                {
                    InputFields[i].Cleanup();
                }
            }
            else
            {
                InputFields.Clear();

                if (inputFields != null)
                {
                    for (int i = 0; i < inputFields.Count; i++)
                    {
                        InputFields.Add(new InputFieldViewModel(inputFields[i],_container));
                    }
                }
                else
                {
                    for (int i = 0; i < BaseNumberOfInputFields; i++)
                    {
                        InputFields.Add(new InputFieldViewModel(new InputFieldModel(), _container));
                    }
                }

                SetAsSetuped();
            }
        }
        
        private void SetAsSetuped()
        {
            _isSetuped = true;
        }
    }
}