namespace Infrastructure.GameStateLogic
{
    public interface IGameStateMachine
    {
        void InitializeMachine();
        void SwitchState(GameState gameState);
    }
}