using Infrastructure.GameStateLogic;

namespace Infrastructure.GameHandlerLogic
{
    public interface IGameHandler
    {
        void SwitchState(GameState state);
    }
}