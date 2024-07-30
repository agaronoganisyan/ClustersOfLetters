using Cysharp.Threading.Tasks;
using Infrastructure.StateMachineLogic;
using Infrastructure.UILogic.UIStateMachineLogic;
using Zenject;

namespace Infrastructure.GameStateLogic
{
    public class Lobby: GameBaseState<GameState>
    {
        public Lobby(IStateMachine<GameState> stateMachine, DiContainer container) : base(stateMachine,container)
        {
            
        }
        
        public override async UniTask Enter()
        {
            _uiStateMachine.SwitchState(UIState.Lobby);
        }
    }
}