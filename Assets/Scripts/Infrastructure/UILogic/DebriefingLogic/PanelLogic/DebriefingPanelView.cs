using System.Collections.Generic;
using ClusterGameplayLogic.InputFieldLogic;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Infrastructure.UILogic.DebriefingLogic.PanelLogic
{
    public class DebriefingPanelView : MonoBehaviour
    {
        private DebriefingPanelViewModel _viewModel;
        
        [SerializeField] private TextMeshProUGUI[] _wordTexts;

        private CompositeDisposable _disposable;
        
        [Inject]
        public virtual void Construct(DiContainer container)
        {
            _viewModel = container.Resolve<DebriefingPanelViewModel>();
            
            _disposable = new CompositeDisposable();
        }

        private void Start()
        {
            _viewModel.OnDisplayFields.Subscribe((value) => DisplayFields(value)).AddTo(_disposable);

            DisplayFields(_viewModel.GetFieldsForDisplay());
        }

        private void DisplayFields(List<InputFieldModel> inputFields)
        {
            for (int i = 0; i < _wordTexts.Length; i++)
            {
                _wordTexts[i].text = inputFields[i].GetWord();
            }
        }
        
        public void OnToLobby()
        {
            _viewModel.ToLobby();
        }
    }
}