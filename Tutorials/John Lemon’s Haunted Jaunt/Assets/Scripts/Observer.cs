using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameEnding gameEnding;

    private bool _canSeePlayer;

    // Update is called once per frame
    private void Update()
    {
        if (!_canSeePlayer) return;
        
        var observerPosition = transform.position;
        var direction = (player.position + Vector3.up) - observerPosition;
        var ray = new Ray(observerPosition, direction);

        if (!Physics.Raycast(ray, out var raycastHit)) return;
            
        if (raycastHit.collider.transform == player)
        {
            gameEnding.WasCaught = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != player) return;
        _canSeePlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform != player) return;
        _canSeePlayer = false;
    }
}