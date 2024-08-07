namespace Infrastructure.DataProviderLogic
{
    public interface IDataProvider
    {
        T LoadData<T>(string pathToFile) where T : new();
        void SaveData<T>(string pathToFile, T data);
        void ClearData(string pathToFile);
    }
}