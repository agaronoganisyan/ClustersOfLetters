using System.Collections.Generic;
using ClusterGameplayLogic.ClusterLogic.FactoryLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic.ListLogic
{
    public class ClustersListView : MonoBehaviour
    {
        private ClustersListViewModel _viewModel;
        private IClustersViewFactory _clustersViewFactory;

        private CompositeDisposable _disposable;

        private RectTransform _rectTransform;
        private int _numAllItems;

        private const float Spacing = 20;
        private const float ClusterBaseLength = 150;
        // private const float ClusterSize = ClusterBaseLength + Spacing;
        private readonly Vector3 _startPos = Vector2.zero;
        private readonly Vector3 _offsetVec = Vector3.right;
        
        private List<ClusterViewModel> _clusters;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _viewModel = container.Resolve<ClustersListViewModel>();
            _clustersViewFactory = container.Resolve<IClustersViewFactory>();

            _rectTransform = GetComponent<RectTransform>();
            
            _disposable = new CompositeDisposable();
            _clusters = new List<ClusterViewModel>();
        }
        
        private void Start()
        {
            _viewModel.Clusters.ObserveRemove().
                Subscribe((value) => ClusterRemoved(value)).AddTo(_disposable);

            _viewModel.OnSetuped.Subscribe(CreateClusters).AddTo(_disposable);

            CreateClusters(_viewModel.Clusters);
        }
        
        private void ClusterRemoved(CollectionRemoveEvent<ClusterViewModel> value)
        {
            
        }
        

        private void CreateClusters(IReadOnlyReactiveCollection<ClusterViewModel> clusters)
        {
            _numAllItems = clusters.Count;
            
            Vector2 size = new Vector2(0, _rectTransform.sizeDelta.y);
            Vector2 origin =new Vector2(Spacing, 0);
            
            for (int i = 0; i < _numAllItems; i++)
            {
                size += new Vector2(clusters[i].Model.Length * ClusterBaseLength + Spacing, 0);
                if (i == _numAllItems-1) size += new Vector2( Spacing, 0);
                
                _clustersViewFactory.Get(clusters[i]);
                
                clusters[i].SetParentAndPosition(_rectTransform,i + 1, origin);
                origin += new Vector2(clusters[i].Model.Length * ClusterBaseLength + Spacing, 0);
                AddItemToList(clusters[i]);
            }
            
            _rectTransform.sizeDelta = size;
            _rectTransform.anchoredPosition = new Vector3(0,_rectTransform.anchoredPosition.y);
        }
        
        private void AddItemToList(ClusterViewModel viewModel)
        {
            _clusters.Add(viewModel);
        }
    }
}