using System;
using ClusterGameplayLogic.ClusterLogic;
using ClusterGameplayLogic.ClusterLogic.ContainerLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic
{
    public class InputFieldView : ClusterContainerView, Infrastructure.PoolLogic.IPoolable<InputFieldView>
    {
        private InputFieldViewModel _viewModel;

        private RectTransform _rectTransform;
        
        private CompositeDisposable _disposable;

        private Action<InputFieldView> _returnToPool;
        
        [Inject]
        private void Construct()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void Setup(InputFieldViewModel viewModel)
        {
            _disposable?.Dispose();
            _disposable = new CompositeDisposable();

            _viewModel = viewModel;
            _viewModel.OnChanged.Subscribe((value) => ReorderField(value)).AddTo(_disposable);
            
            _viewModel.ParentTransform.Subscribe((value) => SetParent(value)).AddTo(_disposable);
            _viewModel.Position.Subscribe((value) => SetPosition(value)).AddTo(_disposable);
            
            gameObject.SetActive(true);
        }

        private void ReorderField(IReadOnlyReactiveCollection<ClusterViewModel> clusters)
        {
            Vector2 origin = Vector2.zero;
            
            for (int i = 0; i < clusters.Count; i++)
            {
                clusters[i].SetParentContainerAndPosition(_rectTransform, origin);
                origin += new Vector2(clusters[i].Model.Length * ClusterStaticData.BaseLength, 0);
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

        protected override ClusterContainerViewModel GetClusterContainerViewModel()
        {
            return _viewModel;
        }
        
        #region POOL_LOGIC
        
        public void PoolInitialize(Action<InputFieldView> returnAction)
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