using System.Collections.Generic;
using ClusterGameplayLogic.InputFieldLogic;
using ClusterGameplayLogic.WordLogic;
using Infrastructure.GameStateLogic;
using UniRx;
using Zenject;

namespace ClusterGameplayLogic.ValidatorLogic
{
    public class GameValidator : IGameValidator
    {
        public ReactiveCommand<List<InputFieldViewModel>> OnResultValidated { get; }
        
        
        private WordsModel _wordsModel;
        private InputFieldsModel _inputFieldsModel;
        private IGameStateMachine _gameStateMachine;
        
        public GameValidator(DiContainer container)
        {
            _wordsModel = container.Resolve<WordsModel>();
            _inputFieldsModel = container.Resolve<InputFieldsModel>();
            _gameStateMachine = container.Resolve<IGameStateMachine>();

            OnResultValidated = new ReactiveCommand<List<InputFieldViewModel>>();
        }

        public void Validate()
        {
            if (AreAllTheWordsCorrect())
            {
                OnResultValidated?.Execute(_inputFieldsModel.InputFields);
                
                _gameStateMachine.SwitchState(GameState.Debriefing);
            }
        }

        public List<InputFieldViewModel> GetValidatedResult()
        {
            return _inputFieldsModel.InputFields;
        }

        private bool AreAllTheWordsCorrect()
        {
            for (int i = 0; i < _inputFieldsModel.InputFields.Count; i++)
            {
                if (!_wordsModel.Words.Contains(_inputFieldsModel.InputFields[i].Model.GetWord()))
                {
                    return false;
                }
            }
    
            return true;     
        }
    }
}