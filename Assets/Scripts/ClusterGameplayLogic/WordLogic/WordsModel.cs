using System.Collections.Generic;
using ClusterGameplayLogic.LevelLogic;

namespace ClusterGameplayLogic.WordLogic
{
    public class WordsModel
    {
        public List<string> Words { get; }

        public WordsModel()
        {
            Words = new List<string>();
        }

        public void Setup(LevelModel model)
        {
            Words.Clear();
            for (int i = 0; i < model.Words.Length; i++)
            {
                Words.Add(model.Words[i]);
            }
        }

        public bool IsThereSuchWord(string word)
        {
            return Words.Contains(word);
        }
    }
}