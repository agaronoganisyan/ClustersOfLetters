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
        private InputFieldsModel _inputFieldsModel;
        private RectTransform _rectTransform;
        private CompositeDisposable _disposable;

        private const float Spacing = 25;
        private readonly Vector3 _startPos = Vector2.zero;
        private readonly Vector3 _offsetVec = Vector3.down;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _inputFieldViewFactory = container.Resolve<IInputFieldFactory>();
            _inputFieldsModel = container.Resolve<InputFieldsModel>();
            _viewModel = container.Resolve<InputFieldsListViewModel>();
            
            _rectTransform = GetComponent<RectTransform>();

            _disposable = new CompositeDisposable();
        }
        
        private void Start()
        {
            _viewModel.InputFields.ObserveCountChanged().
                Subscribe((value) => CreateInputFields(_viewModel.InputFields)).AddTo(_disposable);

            
            _viewModel.OnSetuped.Subscribe(CreateInputFields).AddTo(_disposable);

            CreateInputFields(_viewModel.InputFields);
        }

        private void CreateInputFields(IReadOnlyReactiveCollection<InputFieldViewModel> fields)
        {
            int numAllItems = fields.Count;
            
            Vector2 origin = Vector2.zero;
            
            for (int i = 0; i < numAllItems; i++)
            {
                _inputFieldViewFactory.Get(fields[i]);
                
                fields[i].SetParentAndPosition(_rectTransform, origin);
                //Debug.Log($"fields[i] {i}");
                origin -= new Vector2(0, InputFieldStaticData.BaseHeight + Spacing);
            }
        }
    }
}