using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Text winnerText = default;
    [SerializeField] private Text collectibleText = default;
    [SerializeField] private PlayerModel playerModel = default;

    private int _collectiblesAmountOnScene;

    private void Awake()
    {
        playerModel.OnCollectibleCountChanged += UpdateUI;
        _collectiblesAmountOnScene = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    private void OnDestroy()
    {
        playerModel.OnCollectibleCountChanged -= UpdateUI;
    }

    private void UpdateUI(int collectiblesCount)
    {
        collectibleText.text = collectiblesCount.ToString();
        if (collectiblesCount == _collectiblesAmountOnScene)
        {
            winnerText.enabled = true;
        }
    }
}