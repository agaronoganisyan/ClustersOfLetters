using System.Collections.Generic;
using ClusterGameplayLogic.InputFieldLogic;
using UniRx;

namespace ClusterGameplayLogic.ValidatorLogic
{
    public interface IGameValidator
    {
        ReactiveCommand<List<InputFieldViewModel>> OnResultValidated { get; }
        void Validate();
        List<InputFieldViewModel> GetValidatedResult();
    }
}