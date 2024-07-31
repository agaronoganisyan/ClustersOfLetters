using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagementLogic;
using Infrastructure.ObjectFactoryLogic;
using Infrastructure.PoolLogic;
using UnityEngine;
using Zenject;

namespace ClusterGameplayLogic.ClusterLogic.FactoryLogic
{
    public class ClusterViewFactory<T> : ObjectFactory<T> where T : MonoBehaviour, Infrastructure.PoolLogic.IPoolable<T>
    {
        private IAssetsProvider _assetsProvider;

        private string _address;
        
        public ClusterViewFactory(DiContainer container)
        {
            _pool = container.Resolve<ObjectPool<T>>();
            _assetsProvider = container.Resolve<IAssetsProvider>();
        }
        
        public override async UniTask Setup(string addressToPrefab)
        {
            _address = addressToPrefab;
            
            GameObject prefab = await _assetsProvider.Load<GameObject>(_address);
            _pool.Setup(prefab.GetComponent<T>());
        }

        public ClusterView Get(ClusterViewModel viewModel)
        {
            ClusterView offer = base.Get() as ClusterView;
            offer.Setup(viewModel);
            return offer;
        }
    }
}