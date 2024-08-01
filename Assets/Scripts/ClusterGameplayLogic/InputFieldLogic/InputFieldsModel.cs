using System.Collections.Generic;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic
{
    public class InputFieldsModel
    {
        private readonly DiContainer _container;
        public List<InputFieldViewModel> InputFields { get; }

        private const int BaseNumberOfInputFields = 4;
        
        public InputFieldsModel(DiContainer container)
        {
            _container = container;
            
            InputFields = new List<InputFieldViewModel>();
        }
        
        public void Setup(List<InputFieldModel> inputFields = null)
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
        }
    }
}