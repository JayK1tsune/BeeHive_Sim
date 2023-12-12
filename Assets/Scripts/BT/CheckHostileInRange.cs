using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;
using UnityEngine.AI;

public class CheckHostileInRange : BT_Node
{
    private Transform _transform;
    private NavMeshAgent _agent;
    private BT_DefendBee _DefendBee;
    private FieldOfView _fieldOfView; 

    public static int _enemyLayer = 1 << 6;

    public CheckHostileInRange(Transform transform, NavMeshAgent agent, BT_DefendBee btBee, FieldOfView fov)
    {
        _transform = transform;
        _agent = agent;
        _DefendBee = btBee;
        _fieldOfView = _transform.GetComponent<FieldOfView>(); // Assign FieldOfView component from the transform
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            // Use FieldOfView methods to check for enemies
            _fieldOfView.FieldOfViewCheck();

            if (_fieldOfView.canSeeWasp == true)
            {
                Debug.Log("HELLO FUTURE ME, THIS IS THE PROBLEM");
                // Perform actions when an enemy is detected
                parent.parent.SetData("target", _fieldOfView.currentWasp.transform);
                if (_fieldOfView.currentWasp.transform.parent.parent == null)
                {
                    Debug.Log("HELLO FUTURE ME, THIS IS THE PROBLEM");
                    nodeState = NodeState.FAILURE;
                    return nodeState;
                }
                nodeState = NodeState.SUCCESS;
                return nodeState;
            }

            nodeState = NodeState.FAILURE;
            return nodeState;
        }
        nodeState = NodeState.SUCCESS;
        return nodeState;
    }
}


