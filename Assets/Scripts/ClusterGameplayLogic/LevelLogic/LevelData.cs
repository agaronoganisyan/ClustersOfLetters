using System;

namespace ClusterGameplayLogic.LevelLogic
{
    [Serializable]
    public class LevelData
    {
        public int Level;
        public string[] Words;
    }
    
    [Serializable]
    public class LevelsData
    {
        public LevelData[] Levels;
    }
}