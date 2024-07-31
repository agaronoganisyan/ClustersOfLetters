using System;

namespace Infrastructure.PoolLogic
{
    public interface IPoolable<T>
    {
        void PoolInitialize(Action<T> returnAction);
        void ReturnToPool();
    }
}