using ClusterGameplayLogic.ClusterLogic.ContainerLogic;
using Infrastructure.UILogic.ViewModelLogic;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

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

        public ReactiveCommand<ClusterViewModel> OnDragStarted { get; }
        public ReactiveCommand<PointerEventData> OnDragFinished { get; }

        public ClusterContainerViewModel ClusterContainerViewModel { get; private set; }
        
        private GameplayCanvasViewModel _gameplayCanvasViewModel;

        private Transform _containerParentTransform;
        private Vector2 _positionInContainer;
        private bool _containerIsChanged;
        
        public ClusterViewModel(ClusterModel model, DiContainer container)
        {
            Model = model;

            _gameplayCanvasViewModel = container.Resolve<GameplayCanvasViewModel>();
            
            _parentTransform = new ReactiveProperty<Transform>();
            _position = new ReactiveProperty<Vector2>();
            _index = new ReactiveProperty<int>();

            OnDragStarted = new ReactiveCommand<ClusterViewModel>();
            OnDragFinished = new ReactiveCommand<PointerEventData>();
        }

        public void SetInitClusterContainer(ClusterContainerViewModel containerViewModel)
        {
            ClusterContainerViewModel = containerViewModel;
            _containerIsChanged = false;
        }

        public void SetClusterContainer(ClusterContainerViewModel containerViewModel)
        {
            if (ClusterContainerViewModel == containerViewModel)
            {
                _containerIsChanged = false;
            }
            else
            {
                ClusterContainerViewModel.RemoveCluster(this);
                ClusterContainerViewModel = containerViewModel;
                ClusterContainerViewModel.AddCluster(this);
                _containerIsChanged = true;
            }
        }

        private void BackToPreviousPosition()
        {
            SetParentAndPosition(_containerParentTransform, _positionInContainer);
        }

        public void SetParentContainerAndPosition(Transform parent, Vector2 position)
        {
            _parentTransform.Value = parent;
            _position.Value = position;

            _containerParentTransform = _parentTransform.Value;
            _positionInContainer = _position.Value;
        }
        
        public void SetParentAndPosition(Transform parent, Vector2 position)
        {
            _parentTransform.Value = parent;
            _position.Value = position;
        }

        private void SetParent(Transform parent)
        {
            _parentTransform.Value = parent;
        }

        private void SetPosition(Vector2 position)
        {
            _position.Value = position;
        }
        
        public void SetIndex(int index)
        {
            _index.Value = index;
        }
        
        public void BeginDrag()
        {
            SetParent(_gameplayCanvasViewModel.View.transform);

            OnDragStarted?.Execute(this);
        }
        
        public void Drag(Vector2 delta, Vector2 position)
        {
            SetPosition(position + delta / _gameplayCanvasViewModel.View.Canvas.scaleFactor);
        }
        
        public void EndDrag(PointerEventData eventData)
        {
            if (!_containerIsChanged) BackToPreviousPosition();

            _containerIsChanged = false;
            
            OnDragFinished?.Execute(eventData);
        }
    }
}