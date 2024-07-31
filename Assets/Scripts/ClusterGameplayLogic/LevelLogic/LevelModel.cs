using System;

namespace ClusterGameplayLogic.LevelLogic
{
    [Serializable]
    public class LevelModel
    {
        public int Level;
        public string[] Words;
    }
    
    [Serializable]
    public class LevelsModel
    {
        public LevelModel[] Levels;
    }
}