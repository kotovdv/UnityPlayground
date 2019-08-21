using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private InputField inputField;
    [SerializeField] private GameState gameState;

    private void Start()
    {
        DisplayRoomText();
        inputField.onEndEdit.AddListener(OnPlayerInput);
    }

    private void OnPlayerInput(string input)
    {
        inputField.text = "";
    }

    private void DisplayRoomText()
    {
        var options = string.Join("\n", gameState.CreatePossibleOptions().Select(kv => kv.Key + ") " + kv.Value));
        text.text = gameState.currentRoom.description + "\n" +
                    "Possible options are  \n" + options;
    }
}