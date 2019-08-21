public interface IAction
{
    void Perform(GameState gameState);

    string Description();
}