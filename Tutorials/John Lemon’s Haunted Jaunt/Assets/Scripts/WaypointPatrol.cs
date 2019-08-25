using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    private int _currentWaybillIndex = 0;
    [SerializeField] private Transform[] waybill;
    [SerializeField] private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    private void Start()
    {
        navMeshAgent.SetDestination(waybill[0].position);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)) return;
        
        _currentWaybillIndex = (_currentWaybillIndex + 1) % waybill.Length;
        navMeshAgent.SetDestination (waybill[_currentWaybillIndex].position);
    }
}