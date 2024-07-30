using Cysharp.Threading.Tasks;

namespace Infrastructure.GameStateLogic
{
    public interface IGameStateMachine
    {
        void InitializeMachine();
        void SwitchState(GameState gameState);
    }
}