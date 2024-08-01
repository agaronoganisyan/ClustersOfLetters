using ClusterGameplayLogic.ClusterLogic;
using ClusterGameplayLogic.ClusterLogic.GeneratorLogic;
using ClusterGameplayLogic.WordLogic;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic.ProviderLogic
{
    public class InputFieldsProvider : IInputFieldsProvider
    {
        private WordsModel _wordsModel;
        private InputFieldsModel _inputFieldsModel;
        private IClustersGenerator _generator;
        
        public InputFieldsProvider(DiContainer container)
        {
            _inputFieldsModel = container.Resolve<InputFieldsModel>();
        }

        public void Provide()
        {
            _inputFieldsModel.Setup();
        }
    }
}