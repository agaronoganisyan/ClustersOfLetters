using ClusterGameplayLogic.ClusterLogic;
using ClusterGameplayLogic.ClusterLogic.ContainerLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic
{
    public class InputFieldViewModel : ClusterContainerViewModel
    {
        public InputFieldModel Model { get; }

        public IReadOnlyReactiveProperty<Transform> ParentTransform => _parentTransform;
        private ReactiveProperty<Transform> _parentTransform;
        public IReadOnlyReactiveProperty<Vector2> Position => _position;
        private ReactiveProperty<Vector2> _position;
        
        private bool _isFull;
        private int _currentLength;
        private const int MaxLength = 6;

        public InputFieldViewModel(InputFieldModel model, DiContainer container) : base(container)
        {
            Model = model;
            
            _parentTransform = new ReactiveProperty<Transform>();
            _position = new ReactiveProperty<Vector2>();
        }

        public override bool IsCanAddCluster(ClusterViewModel clusterViewModel)
        {
            if (_isFull) return false;
            if (clusterViewModel.Model.Length + _currentLength > MaxLength) return false;
            
            return true;
        }

        public override void AddCluster(ClusterViewModel clusterViewModel)
        {
            base.AddCluster(clusterViewModel);
            _currentLength += clusterViewModel.Model.Length;
            Model.AddCluster(clusterViewModel.Model);
        }

        public override void RemoveCluster(ClusterViewModel clusterViewModel)
        {
            base.RemoveCluster(clusterViewModel);
            _currentLength -= clusterViewModel.Model.Length;
            Model.RemoveCluster(clusterViewModel.Model);
        }
        
        public void SetParentAndPosition(Transform parent, Vector2 position)
        {
            _parentTransform.Value = parent;
            _position.Value = position;
        }
    }
}