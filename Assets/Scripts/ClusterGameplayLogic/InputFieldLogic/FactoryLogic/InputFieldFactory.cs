using Cysharp.Threading.Tasks;
using UniRx;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic.FactoryLogic
{
    public class InputFieldFactory : IInputFieldFactory
    {
        public ReactiveCommand OnSetuped { get; private set; }
        private bool _isSetuped;

        private InputFieldViewFactory<InputFieldView> _viewFactory;
        
        private const string _address = "InputFieldView";

        public InputFieldFactory(DiContainer container)
        {
            OnSetuped = new ReactiveCommand();
            
            _viewFactory = container.Resolve<InputFieldViewFactory<InputFieldView>>();
        }

        public async UniTask Setup()
        {
            if (_isSetuped) return;
            
            await _viewFactory.Setup(_address);

            SetAsSetuped();
        }

        public void ReturnAllBack()
        {
            _viewFactory.ReturnAllObjectToPool();
        }

        public InputFieldView Get(InputFieldViewModel viewModel)
        {
            return _viewFactory.Get(viewModel);
        }
                
        private void SetAsSetuped()
        {
            _isSetuped = true;
            OnSetuped.Execute();
        }
    }
}