using System;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic
{
    public class ClusterView : MonoBehaviour, Infrastructure.PoolLogic.IPoolable<ClusterView>
    {
        private ClusterViewModel _viewModel;
        private RectTransform _rectTransform;

        private CompositeDisposable _disposable;
        
        [SerializeField] private TextMeshProUGUI[] _lettersTexts;
        
        private Action<ClusterView> _returnToPool;
        
        [Inject]
        private void Construct()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
        
        public void Setup(ClusterViewModel viewModel)
        {
            _disposable = new CompositeDisposable();
            
            _viewModel = viewModel;

            _viewModel.ParentTransform.Subscribe((value) => SetParent(value)).AddTo(_disposable);
            _viewModel.Position.Subscribe((value) => SetPosition(value)).AddTo(_disposable);
            
            ConfigureView(_viewModel.Model.Value, _viewModel.Model.Length);
            
            gameObject.SetActive(true);
        }

        private void ConfigureView(string value, int length)
        {
            char[] letters = value.ToCharArray();
            
            for (int i = 0; i < length; i++)
            {
                _lettersTexts[i].text = letters[i].ToString();
            }
        }
        
        private void SetParent(Transform parent)
        {
            _rectTransform.SetParent(parent);
            _rectTransform.localScale = Vector3.one;
        }

        private void SetPosition(Vector2 position)
        {
            _rectTransform.anchoredPosition = position;   
        }
        
        #region POOL_LOGIC
        
        public void PoolInitialize(Action<ClusterView> returnAction)
        {
            _returnToPool = returnAction;
        }
        
        public virtual void ReturnToPool()
        {
            _returnToPool?.Invoke(this);
        }
        
        #endregion
    }
}