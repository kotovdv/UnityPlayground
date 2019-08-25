using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    private const float FadeDuration = 1f;
    private const float DisplayEndGameImageDuration = 2f;

    [SerializeField] private GameObject player;
    [SerializeField] private CanvasGroup positiveEndingCanvasGroup;
    [SerializeField] private CanvasGroup negativeEndingCanvasGroup;

    public bool WasCaught { private get; set; }
    private bool _hasTriggeredExitSequence;
    private readonly Stopwatch _stopwatch = new Stopwatch();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != player) return;
        _hasTriggeredExitSequence = true;

    }

    private void Update()
    {
        if (_hasTriggeredExitSequence)
        {
            EndLevel(positiveEndingCanvasGroup, false);
        }
        else if (WasCaught)
        {
            EndLevel(negativeEndingCanvasGroup, true);
        }
    }

    private void EndLevel(CanvasGroup canvasGroup, bool restartLevel)
    {
        _stopwatch.Start();
        
        var elapsedSeconds = _stopwatch.Elapsed.TotalSeconds;
        canvasGroup.alpha = (float) (elapsedSeconds / FadeDuration);

        if (!(elapsedSeconds > FadeDuration + DisplayEndGameImageDuration)) return;
        
        if (restartLevel)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            Application.Quit();
        }
    }
}