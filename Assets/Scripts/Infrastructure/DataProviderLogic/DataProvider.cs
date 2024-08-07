using System.IO;
using UnityEngine;

namespace Infrastructure.DataProviderLogic
{
    public class DataProvider : IDataProvider
    {
        private string PathPersistentDataPath = Application.persistentDataPath + "/";

        public T LoadData<T>(string pathToFile) where T : new()
        {
            string path = PathPersistentDataPath + pathToFile;
        
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                Debug.Log($"JSON read: {json}");
                T data = JsonUtility.FromJson<T>(json);
                return data;
            }
            else
            {
                Debug.LogWarning("File does not exist, returning new instance.");
                return new T();
            }
        }

        public void SaveData<T>(string pathToFile, T data)
        {
            string json = JsonUtility.ToJson(data);
            Debug.Log($"JSON to save: {json}");
            File.WriteAllText(PathPersistentDataPath + pathToFile, json);
        }

        public void ClearData(string pathToFile)
        {
            string path = PathPersistentDataPath + pathToFile;
        
            if (File.Exists(path))
            {
                File.Delete(path);
                Debug.Log($"File {pathToFile} deleted.");
            }
            else
            {
                Debug.LogWarning($"File {pathToFile} does not exist.");
            }
        }
    }
}