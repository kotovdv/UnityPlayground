using System;

[Serializable]
public class Exit : IAction
{
    public string keyString;
    public string exitDescription;
    public Room valueRoom;
    
    public void Perform(GameState gameState)
    {
        gameState.currentRoom = valueRoom;
    }

    public string Description()
    {
        return keyString;
    }
}