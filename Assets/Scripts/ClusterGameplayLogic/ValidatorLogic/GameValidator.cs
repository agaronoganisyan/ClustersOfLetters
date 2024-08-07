using System.Collections.Generic;
using ClusterGameplayLogic.InputFieldLogic;
using ClusterGameplayLogic.InputFieldLogic.ListLogic;
using ClusterGameplayLogic.WordLogic;
using Infrastructure.GameStateLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace ClusterGameplayLogic.ValidatorLogic
{
    public class GameValidator : IGameValidator
    {
        public ReactiveCommand<List<InputFieldModel>> OnResultValidated { get; }
        
        private WordsModel _wordsModel;
        private InputFieldsListModel _inputFieldsListModel;
        
        public GameValidator(DiContainer container)
        {
            _wordsModel = container.Resolve<WordsModel>();
            _inputFieldsListModel = container.Resolve<InputFieldsListModel>();

            OnResultValidated = new ReactiveCommand<List<InputFieldModel>>();
        }

        public void Validate()
        {
            if (AreAllTheWordsCorrect())
            {
                OnResultValidated?.Execute(_inputFieldsListModel.InputFields);
            }
        }

        public List<InputFieldModel> GetValidatedResult()
        {
            return _inputFieldsListModel.InputFields;
        }

        private bool AreAllTheWordsCorrect()
        {
            for (int i = 0; i < _inputFieldsListModel.InputFields.Count; i++)
            {
                if (!_wordsModel.Words.Contains(_inputFieldsListModel.InputFields[i].GetWord()))
                {
                    return false;
                }
            }
    
            return true;     
        }
    }
}