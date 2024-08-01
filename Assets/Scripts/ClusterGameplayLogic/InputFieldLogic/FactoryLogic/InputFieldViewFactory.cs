using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagementLogic;
using Infrastructure.ObjectFactoryLogic;
using Infrastructure.PoolLogic;
using UnityEngine;
using Zenject;

namespace ClusterGameplayLogic.InputFieldLogic.FactoryLogic
{
    public class InputFieldViewFactory <T> : ObjectFactory<T> where T : MonoBehaviour, Infrastructure.PoolLogic.IPoolable<T>
    {
        private IAssetsProvider _assetsProvider;
        
        public InputFieldViewFactory(DiContainer container)
        {
            _pool = container.Resolve<ObjectPool<T>>();
            _assetsProvider = container.Resolve<IAssetsProvider>();
        }
        
        public override async UniTask Setup(string addressToPrefab)
        {
            GameObject prefab = await _assetsProvider.Load<GameObject>(addressToPrefab);
            _pool.Setup(prefab.GetComponent<T>());
        }

        public InputFieldView Get(InputFieldViewModel viewModel)
        {
            InputFieldView fieldView = base.Get() as InputFieldView;
            fieldView.Setup(viewModel);
            return fieldView;
        }
    }
}