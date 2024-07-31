using Cysharp.Threading.Tasks;
using Infrastructure.PoolLogic;
using UnityEngine;

namespace Infrastructure.ObjectFactoryLogic
{
    public abstract class ObjectFactory<T> : IFactory<T> where T : MonoBehaviour, IPoolable<T>
    {
        protected IPool<T> _pool;

        public abstract UniTask Setup(string addressToPrefab);

        public T Get()
        {
            return _pool.Pull();
        }

        public void ReturnAllObjectToPool()
        {
            _pool.PushBackAll();
        }
    }
}