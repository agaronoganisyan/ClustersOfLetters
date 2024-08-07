using System.Collections.Generic;
using ClusterGameplayLogic.InputFieldLogic;
using UniRx;

namespace ClusterGameplayLogic.ValidatorLogic
{
    public interface IGameValidator
    {
        ReactiveCommand<List<InputFieldModel>> OnResultValidated { get; }
        void Validate();
        List<InputFieldModel> GetValidatedResult();
    }
}