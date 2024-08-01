using ClusterGameplayLogic.InputFieldLogic.FactoryLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic.ListLogic
{
    public class InputFieldsListView : MonoBehaviour
    {
        private InputFieldsListViewModel _viewModel;
        private IInputFieldFactory _inputFieldViewFactory;
        private RectTransform _rectTransform;
        private CompositeDisposable _disposable;

        private const float Spacing = 25;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _inputFieldViewFactory = container.Resolve<IInputFieldFactory>();
            _viewModel = container.Resolve<InputFieldsListViewModel>();
            
            _rectTransform = GetComponent<RectTransform>();

            _disposable = new CompositeDisposable();
        }
        
        private void Start()
        {
            _viewModel.OnSetuped.Subscribe(CreateInputFields).AddTo(_disposable);

            CreateInputFields(_viewModel.InputFields);
        }

        private void CreateInputFields(IReadOnlyReactiveCollection<InputFieldViewModel> fields)
        {
            int numAllItems = fields.Count;
            
            Vector2 origin = Vector2.zero;
            
            for (int i = 0; i < numAllItems; i++)
            {
                InputFieldView view = _inputFieldViewFactory.Get(fields[i]);
                view.transform.SetParent(_rectTransform); //намеренно добавлено, потому что иначе какой-то глюк c UniRx 
                view.GetComponent<RectTransform>().anchoredPosition = origin; //при размещении первого поля

                fields[i].SetParentAndPosition(_rectTransform, origin);

                origin -= new Vector2(0, InputFieldStaticData.BaseHeight + Spacing);
            }
        }
    }
}