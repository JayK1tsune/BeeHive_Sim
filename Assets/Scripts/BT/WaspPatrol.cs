using UnityEngine;
using BT;
using UnityEngine.AI;

public class WaspPatrol : BT_Node
{
    private Transform _transform;
    private Transform[] _flowers;
    private NavMeshAgent _agent;
    private BT_Wasp _btWasp;
    private int _currentWaypointIndex = 0;

    private float _waitTime = 1.5f; // Cooldown time after reaching a waypoint
    private float _waitCounter = 0f;
    private bool _waiting = false;

    public WaspPatrol(Transform transform, Transform[] flowers, NavMeshAgent agent, BT_Wasp btWasp)
    {
        _transform = transform;
        _flowers = flowers;
        _agent = agent;
        _btWasp = btWasp;
    }

    public override NodeState Evaluate()
    {
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
            {
                _waiting = false;
                _waitCounter = 0f;

                // Select the next waypoint
                _currentWaypointIndex = Random.Range(0, _flowers.Length);
            }
        }
        else
        {
            Transform wp = _flowers[_currentWaypointIndex];
            if (Vector3.Distance(_transform.position, wp.position) < 1.5f)
            {
                // Reached the waypoint, start the cooldown
                _waiting = true;
            }
            else
            {
                _agent.SetDestination(wp.position);
            }
        }

        nodeState = NodeState.RUNNING;
        return nodeState;
    }
}




