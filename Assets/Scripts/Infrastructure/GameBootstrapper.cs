using System;
using Infrastructure.AssetManagementLogic;
using Infrastructure.GameStateLogic;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        private void Awake()
        {
            _container.Resolve<IGameStateMachine>().SwitchState(GameState.Lobby);
        }
    }
}
