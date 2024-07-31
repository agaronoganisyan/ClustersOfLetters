using System;
using System.Collections.Generic;
using ClusterGameplayLogic.ClusterLogic;
using ClusterGameplayLogic.LevelLogic;
using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagementLogic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace ClusterGameplayLogic.WordLogic.ProviderLogic
{
    public class WordsProvider : IWordsProvider
    {
        private const string LevelsDataAddress = "LevelsData";
        
        private IAssetsProvider _assetsProvider;
        private WordsModel _wordsModel;
        private LevelsModel _levelsModel;
        
        public WordsProvider(DiContainer container)
        {
            _assetsProvider = container.Resolve<IAssetsProvider>();
            _wordsModel = container.Resolve<WordsModel>();
        }

        public async UniTask Provide()
        {
            if (_levelsModel == null)
            {
                TextAsset jsonFile = await _assetsProvider.Load<TextAsset>(LevelsDataAddress);
                _levelsModel = JsonUtility.FromJson<LevelsModel>(jsonFile.text);   
            }
            
            _wordsModel.Setup(_levelsModel.Levels[0]);
        }
    }
}