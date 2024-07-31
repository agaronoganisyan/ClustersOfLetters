using System;
using System.Collections.Generic;
using System.Text;
using ClusterGameplayLogic.WordLogic;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace ClusterGameplayLogic.ClusterLogic.GeneratorLogic
{
    public class ClustersGenerator : IClustersGenerator
    {
        private WordsModel _wordsModel;

        public ClustersGenerator(DiContainer container)
        {
            _wordsModel = container.Resolve<WordsModel>();
        }
        
        public List<ClusterModel> GenerateRandomClusters()
        {
            List<ClusterModel> clusters = new List<ClusterModel>();
            Random random = new Random();

            foreach (var word in _wordsModel.Words)
            {
                StringBuilder remainingLetters = new StringBuilder(word);
        
                while (remainingLetters.Length > 0)
                {
                    int maxClusterLength = Math.Min(4, remainingLetters.Length);
                    int clusterLength = remainingLetters.Length switch
                    {
                        3 => 3,
                        4 => 2,
                        _ => random.Next(2, maxClusterLength + 1)
                    };

                    string clusterValue = remainingLetters.ToString(0, clusterLength);
                    clusters.Add(new ClusterModel(clusterValue, clusterLength));
                    remainingLetters.Remove(0, clusterLength);
                }
            }

            Shuffle(clusters, random);
            
            return clusters;
        }
        
        private void Shuffle<T>(List<T> list, Random random)
        {
            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                if (i != j)
                {
                    T temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }
    }
}