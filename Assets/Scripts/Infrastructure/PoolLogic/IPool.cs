namespace Infrastructure.PoolLogic
{
    public interface IPool<T>
    {
        void Setup(T prefab, int initialSize);
        void Setup(T prefab);
        T Pull();
        void PushBackAll();
    }
}