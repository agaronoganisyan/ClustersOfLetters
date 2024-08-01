using UnityEngine;
using Zenject;

namespace ClusterGameplayLogic.ValidatorLogic
{
    public class ValidatorView : MonoBehaviour
    {
        private IGameValidator _gameValidator;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _gameValidator = container.Resolve<IGameValidator>();
        }

        public void OnValidateGame()
        {
            _gameValidator.Validate();
        }
    }
}