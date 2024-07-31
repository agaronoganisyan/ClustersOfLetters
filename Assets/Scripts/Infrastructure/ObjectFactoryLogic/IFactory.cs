namespace Infrastructure.ObjectFactoryLogic
{
    public interface IFactory<T>
    {
        T Get();
    }
}