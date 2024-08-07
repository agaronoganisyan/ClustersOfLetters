using System.Collections.Generic;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic.ListLogic
{
    public class InputFieldsListModel
    {
        private readonly DiContainer _container;
        public List<InputFieldModel> InputFields { get; }

        private const int BaseNumberOfInputFields = 4;
        
        private bool _isSetuped;
        
        public InputFieldsListModel(DiContainer container)
        {
            _container = container;
            
            InputFields = new List<InputFieldModel>();
        }
        
        public void Setup(List<InputFieldModel> inputFields = null)
        {
            if (_isSetuped) return;

            InputFields.Clear();

            if (inputFields != null && inputFields.Count > 0)
            {
                for (int i = 0; i < inputFields.Count; i++)
                {
                    InputFields.Add(inputFields[i]);
                }
            }
            else
            {
                for (int i = 0; i < BaseNumberOfInputFields; i++)
                {
                    InputFields.Add(new InputFieldModel());
                }
            }

            SetAsSetuped();
        }
        
        private void SetAsSetuped()
        {
            _isSetuped = true;
        }
    }
}