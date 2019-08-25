using System;
using System.Diagnostics;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    private const float FadeDuration = 1f;
    private const float DisplayEndGameImageDuration = 2f;
    
    [SerializeField] private GameObject player;
    [SerializeField] private CanvasGroup gameEndingCanvasGroup;

    private bool _hasTriggeredExitSequence;
    private readonly Stopwatch _stopwatch = new Stopwatch();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != player) return;
        _hasTriggeredExitSequence = true;
        _stopwatch.Start();
    }

    private void Update()
    {
        if (!_hasTriggeredExitSequence) return;
        
        var elapsedSeconds = _stopwatch.Elapsed.TotalSeconds;
        gameEndingCanvasGroup.alpha = (float) (elapsedSeconds / FadeDuration);
        
        if (elapsedSeconds > FadeDuration + DisplayEndGameImageDuration)
        {
            Application.Quit();
        }
    }
}