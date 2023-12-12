using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;
using UnityEngine.AI;

public class TaskGoTowardsWasp : BT_Node
{
    private Transform _transform;
    private NavMeshAgent _agent;
    private BT_DefendBee _DefenceBee;  
    FieldOfView _fov;


    public TaskGoTowardsWasp(Transform transform, NavMeshAgent agent, BT_DefendBee btBee)
    {
        _transform = _fov.transform;
        _agent = agent;
        _DefenceBee = btBee;

    }

    public override NodeState Evaluate()
    { 
        Transform target = (Transform)GetData("target");
        Debug.Log($"_transform: {_transform}, _agent: {_agent}, _DefenceBee: {_DefenceBee}, target: {target}");
        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            _agent.SetDestination(target.position);
            Debug.Log("Going towards wasp");
        }
        nodeState = NodeState.RUNNING;
        return nodeState;

    }



}
