using ClusterGameplayLogic.ClusterLogic.ContainerLogic;
using ClusterGameplayLogic.ClusterLogic.FactoryLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic.ListLogic
{
    public class ClustersListView : ClusterContainerView
    {
        private ClustersListViewModel _viewModel;
        private IClustersViewFactory _clustersViewFactory;

        private CompositeDisposable _disposable;

        private RectTransform _rectTransform;

        private const float Spacing = 20;
        private readonly Vector3 _startPos = Vector2.zero;
        private readonly Vector3 _offsetVec = Vector3.right;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _viewModel = container.Resolve<ClustersListViewModel>();
            _clustersViewFactory = container.Resolve<IClustersViewFactory>();

            _rectTransform = GetComponent<RectTransform>();
            
            _disposable = new CompositeDisposable();
        }
        
        private void Start()
        {
            _viewModel.Clusters.ObserveCountChanged().Subscribe((value) => ReorderClusters(_viewModel.Clusters)).AddTo(_disposable);
            
            // _viewModel.Clusters.ObserveRemove().
            //     Subscribe((value) => ClusterRemoved(value)).AddTo(_disposable);

            _viewModel.OnSetuped.Subscribe(CreateClusters).AddTo(_disposable);

            CreateClusters(_viewModel.Clusters);
        }

        private void ReorderClusters(IReadOnlyReactiveCollection<ClusterViewModel> clusters)
        {
            ProcessClusters(clusters, false);
        }

        private void CreateClusters(IReadOnlyReactiveCollection<ClusterViewModel> clusters)
        {
            ProcessClusters(clusters, true);
        }

        private void ProcessClusters(IReadOnlyReactiveCollection<ClusterViewModel> clusters, bool createClusters)
        {
            int numAllItems = clusters.Count;
            Vector2 size = new Vector2(0, _rectTransform.sizeDelta.y);
            Vector2 origin = new Vector2(Spacing, 0);

            for (int i = 0; i < numAllItems; i++)
            {
                size += new Vector2(clusters[i].Model.Length * ClusterStaticData.BaseLength + Spacing, 0);
                if (i == numAllItems - 1) size += new Vector2(Spacing, 0);

                if (createClusters)
                {
                    _clustersViewFactory.Get(clusters[i]);
                }

                clusters[i].SetParentContainerAndPosition(_rectTransform, origin);
                origin += new Vector2(clusters[i].Model.Length * ClusterStaticData.BaseLength + Spacing, 0);
            }

            _rectTransform.sizeDelta = size;
            _rectTransform.anchoredPosition = new Vector3(0, _rectTransform.anchoredPosition.y);
        }


        public override ClusterContainerViewModel GetClusterContainerViewModel()
        {
            return _viewModel;
        }
    }
}