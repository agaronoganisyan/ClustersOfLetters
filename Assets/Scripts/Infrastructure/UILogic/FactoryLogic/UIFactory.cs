using System;
using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagementLogic;
using Infrastructure.UILogic.UIStateMachineLogic;
using Infrastructure.UILogic.ViewLogic;
using UnityEngine;
using Zenject;

namespace Infrastructure.UILogic.FactoryLogic
{
    public class UIFactory : IUIFactory
    {
        private DiContainer _container;

        private IAssetsProvider _assetsProvider;
        
        private readonly string _lobbyCanvasAddress = "CanvasView_Lobby";
        private readonly string _matchCanvasAddress = "CanvasView_Gameplay";
        private readonly string _debriefingCanvasAddress = "CanvasView_Debriefing";

        public UIFactory(DiContainer container)
        {
            _container = container;

            _assetsProvider = _container.Resolve<IAssetsProvider>();
        }

        public async UniTask<CanvasView> GetCanvas(UIState canvasType)
        {
            switch (canvasType)
            {
                case UIState.Lobby:
                    return await LoadAndInstantiateCanvas(_lobbyCanvasAddress);
                case UIState.Gameplay:
                    return await LoadAndInstantiateCanvas(_matchCanvasAddress);
                case UIState.Debriefing:
                    return await LoadAndInstantiateCanvas(_debriefingCanvasAddress);
                default:
                    throw new ArgumentOutOfRangeException(nameof(canvasType), canvasType, null);
            }
        }

        private async UniTask<CanvasView> LoadAndInstantiateCanvas(string address)
        {
            GameObject prefab = await _assetsProvider.Load<GameObject>(address);
            return _container.InstantiatePrefab(prefab).GetComponent<CanvasView>();
        }
        
    }
}