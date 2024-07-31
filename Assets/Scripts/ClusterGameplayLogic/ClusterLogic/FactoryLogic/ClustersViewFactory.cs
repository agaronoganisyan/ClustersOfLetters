using System;
using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagementLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic.FactoryLogic
{
    public class ClustersViewFactory : IClustersViewFactory
    {
        public ReactiveCommand OnSetuped { get; private set; }
        private bool _isSetuped;
        
        private DiContainer _container;
        private IAssetsProvider _assetsProvider;

        private ClusterViewFactory<ClusterView> _clusterLength2Factory;
        private ClusterViewFactory<ClusterView> _clusterLength3Factory;
        private ClusterViewFactory<ClusterView> _clusterLength4Factory;
        
        private const string Cluster2Address = "ClusterView_2";
        private const string Cluster3Address = "ClusterView_3";
        private const string Cluster4Address = "ClusterView_4";

        public ClustersViewFactory(DiContainer container)
        {
            _container = container;

            _clusterLength2Factory = _container.Resolve<ClusterViewFactory<ClusterView>>();
            _clusterLength3Factory = _container.Resolve<ClusterViewFactory<ClusterView>>();
            _clusterLength4Factory = _container.Resolve<ClusterViewFactory<ClusterView>>();

            OnSetuped = new ReactiveCommand();
        }

        public async UniTask Setup()
        {
            if (_isSetuped) return;
            
            await _clusterLength2Factory.Setup(Cluster2Address);
            await _clusterLength3Factory.Setup(Cluster3Address);
            await _clusterLength4Factory.Setup(Cluster4Address);

            SetAsSetuped();
        }
        
        public ClusterView Get(ClusterViewModel viewModel)
        {
            if (viewModel.Model.Length == 2)
            {
                return _clusterLength2Factory.Get(viewModel);
            }
            else if (viewModel.Model.Length == 3)
            {
                return _clusterLength3Factory.Get(viewModel);
            }
            else if (viewModel.Model.Length == 4)
            {
                return _clusterLength4Factory.Get(viewModel);
            }
            else
            {
                throw new ArgumentOutOfRangeException(null);
            }
        }
        
        
        private void SetAsSetuped()
        {
            _isSetuped = true;
            OnSetuped.Execute();
        }
    }
}