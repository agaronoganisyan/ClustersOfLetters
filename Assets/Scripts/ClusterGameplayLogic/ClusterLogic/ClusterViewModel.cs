using UniRx;
using UnityEngine;

namespace ClusterGameplayLogic.ClusterLogic
{
    public class ClusterViewModel
    {
        public ClusterModel Model { get; }

        public IReadOnlyReactiveProperty<int> Index => _index;
        private ReactiveProperty<int> _index;
        public IReadOnlyReactiveProperty<Transform> ParentTransform => _parentTransform;
        private ReactiveProperty<Transform> _parentTransform;
        public IReadOnlyReactiveProperty<Vector2> Position => _position;
        private ReactiveProperty<Vector2> _position;
        
        public ClusterViewModel(ClusterModel model)
        {
            Model = model;
            
            _parentTransform = new ReactiveProperty<Transform>();
            _position = new ReactiveProperty<Vector2>();
            _index = new ReactiveProperty<int>();
        }
        
        public void SetParentAndPosition(Transform parent, int index, Vector2 position)
        {
            _parentTransform.Value = parent;
            SetIndex(index);
            _position.Value = position;
        }

        public void SetPosition(int index, Vector2 position)
        {
            SetIndex(index);
            _position.Value = position;
        }
        
        public void SetIndex(int index)
        {
            _index.Value = index;
        }
    }
}